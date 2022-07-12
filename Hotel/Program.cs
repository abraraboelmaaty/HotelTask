using Hotel.Models;
using Hotel.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Hotel.Healpers;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<JWT>(builder.Configuration.GetSection("JWT"));
builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<HotelEnteties>();
builder.Services.AddControllers();
//builder.Services.Configure<JwtRepo>(builder.Configuration.GetValue<string>("JwtSettings:Key"));
//var jwtKey = Configuration.GetValue<string>("JwtSettings:Key");
//var keyBytes = Encoding.ASCII.GetBytes(jwtKey);
builder.Services.AddDbContext<HotelEnteties>(h => h
                .UseSqlServer(builder.Configuration.GetConnectionString("HotelConn"))
                .UseValidationCheckConstraints()
                .UseEnumCheckConstraints());

builder.Services.AddScoped<IRepository<Branch>, BranchRepo>();
builder.Services.AddScoped<IRepoGetByLocation<Branch>, BranchRepo>();
builder.Services.AddScoped<IRepository<Room>, RoomRepo>();
builder.Services.AddScoped<IRepoGetByNumber<Room>,RoomRepo>();
builder.Services.AddScoped<IRepoGetByTpe<Room>, RoomRepo>();
builder.Services.AddScoped<IRepository<Booking>, BookingRepo>();
builder.Services.AddScoped<IRepoUpdateDelete<Booking>, BookingRepo>();
builder.Services.AddScoped<IRepositoryBooking<Booking>, BookingRepo>();
builder.Services.AddScoped<IAuthRepository, AuthRepo>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(o =>
    {
        o.RequireHttpsMetadata = false;
        o.SaveToken = false;
        o.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidIssuer = builder.Configuration["JWT:Issuer"],
            ValidAudience = builder.Configuration["JWT:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"])),
            ClockSkew = TimeSpan.Zero
        };
    });

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
    builder =>
    {
        builder.AllowAnyOrigin();
        builder.AllowAnyMethod();
        builder.AllowAnyHeader();
    });
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
