using Hotel.DTO;
using Hotel.Models;

namespace Hotel.Repositories
{
    public interface IAuthRepository
    {
        Task<AuthModel> RegisterAsync(Register model);
        //Task<AuthModel> GetTokenAsync(TokenRequestModel model);
        //// Task<string> AddRoleAsync(AddRoleModel model);
        //Task<AuthModel> RefreshTokenAsync(string token);
        //Task<bool> RevokeTokenAsync(string token);
    }
}
