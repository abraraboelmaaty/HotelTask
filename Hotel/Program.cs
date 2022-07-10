using Hotel.Models;
using Hotel.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<HotelEnteties>(h => h
                .UseSqlServer(builder.Configuration.GetConnectionString("HotelConn"))
                .UseValidationCheckConstraints()
                .UseEnumCheckConstraints());
builder.Services.AddScoped<IRepository<Branch>, BranchRepo>();
builder.Services.AddScoped<IRepoGetByLocation<Branch>, BranchRepo>();
builder.Services.AddScoped<IRepository<Room>, RoomRepo>();
builder.Services.AddScoped<IRepoGetByNumber<Room>,RoomRepo>();
builder.Services.AddScoped<IRepoGetByTpe<Room>, RoomRepo>();

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
app.UseAuthorization();

app.MapControllers();

app.Run();
