using Hotel.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Claims;
using Hotel.DTO;
using Microsoft.AspNetCore.Identity;
using Hotel.Healpers;
using Microsoft.Extensions.Options;

namespace Hotel.Repositories
{
    public class AuthRepo : IAuthRepository
    {
        //private readonly HotelEnteties context;
        //private readonly IConfiguration configuration;

        //public AuthRepo(HotelEnteties _context, IConfiguration _configuration)
        //{
        //    context = _context;
        //    configuration = _configuration;
        //}
        //public async Task<string> GetTokenAsync(AuthRequest authRequest)
        //{
        //    var user = context.Coustomers.FirstOrDefault(c=>c.UserName.Equals(authRequest.UserName)
        //    && c.password.Equals(authRequest.Password));

        //    if (user == null)
        //        return await Task.FromResult<string>(null);
        //    var jwtKey = configuration.GetValue<string>("JwtSettings:Key");
        //    var keyBytes = Encoding.ASCII.GetBytes(jwtKey);
        //    var tokenHandler = new JwtSecurityTokenHandler();
        //    var descriptor = new SecurityTokenDescriptor()
        //    {
        //        Subject = new ClaimsIdentity(new Claim[]
        //        {
        //            new Claim(ClaimTypes.NameIdentifier,user.UserName)
        //        }),
        //        Expires = DateTime.UtcNow.AddSeconds(60),
        //        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyBytes),
        //        SecurityAlgorithms.HmacSha256)
        //    };
        //    var token = tokenHandler.CreateToken(descriptor);
        //    return await Task.FromResult(tokenHandler.WriteToken(token));
        //}
        public AuthRepo(UserManager<ApplicationUser> _userManager, RoleManager<IdentityRole> _roleManager,
            IOptions<JWT> _jwt)
        {
            userManager = _userManager;
            jwt = _jwt.Value;
            roleManager = _roleManager;
        }
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly JWT jwt;
        public async Task<AuthModel> RegisterAsync(Register model)
        {
            if (await userManager.FindByEmailAsync(model.Email) is not null)
                return new AuthModel { Message = "Email is already registered!" };

            if (await userManager.FindByNameAsync(model.Username) is not null)
                return new AuthModel { Message = "Username is already registered!" };
            var user = new ApplicationUser
            {
                UserName = model.Username,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName
            };
            var result = await userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                var errors = string.Empty;

                foreach (var error in result.Errors)
                    errors += $"{error.Description},";

                return new AuthModel { Message = errors };
            }
            await userManager.AddToRoleAsync(user, "Customer");
            var jwtSecurityToken = await CreateJwtToken(user);


            await userManager.UpdateAsync(user);


            return new AuthModel
            {
                Email = user.Email,
                ExpiresOn = jwtSecurityToken.ValidTo,
                IsAuthenticated = true,
                Roles = new List<string> { "Customer" },
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                Username = user.UserName,

            };
        }
        public async Task<AuthModel> GetTokenAsync(TokenRequestModel model)
        {
            var authModel = new AuthModel();

            var user = await userManager.FindByEmailAsync(model.Email);

            if (user is null || !await userManager.CheckPasswordAsync(user, model.Password))
            {
                authModel.Message = "Email or Password is incorrect!";
                return authModel;
            }

            var jwtSecurityToken = await CreateJwtToken(user);
            var rolesList = await userManager.GetRolesAsync(user);

            authModel.IsAuthenticated = true;
            authModel.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            authModel.Email = user.Email;
            authModel.Username = user.UserName;
            authModel.ExpiresOn = jwtSecurityToken.ValidTo;
            authModel.Roles = rolesList.ToList();

            return authModel;
        }
        public async Task<string> AddRoleAsync(AddRoleModel model)
        {
            var user = await userManager.FindByIdAsync(model.UserId);

            if (user is null || !await roleManager.RoleExistsAsync(model.Role))
                return "Invalid user ID or Role";

            if (await userManager.IsInRoleAsync(user, model.Role))
                return "User already assigned to this role";

            var result = await userManager.AddToRoleAsync(user, model.Role);

            return result.Succeeded ? string.Empty : "Sonething went wrong";
        }
        private async Task<JwtSecurityToken> CreateJwtToken(ApplicationUser user)
        {
            var userClaims = await userManager.GetClaimsAsync(user);
            var roles = await userManager.GetRolesAsync(user);
            var roleClaims = new List<Claim>();

            foreach (var role in roles)
                roleClaims.Add(new Claim("roles", role));

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("uid", user.Id)
            }
            .Union(userClaims)
            .Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: jwt.Issuer,
                audience: jwt.Audience,
                claims: claims,
                expires: DateTime.Now.AddDays(jwt.DurationInMinutes),
                signingCredentials: signingCredentials);

            return jwtSecurityToken;
        }
    }
}
