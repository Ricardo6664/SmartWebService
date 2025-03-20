using Microsoft.EntityFrameworkCore;
using SmartWebService.Bussiness;
using SmartWebService.Infra;
using SmartWebService.Infra.Interfaces;
using SmartWebService.Infra.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DbContextInfra>( options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
builder.Services.AddScoped<IUser, UserService>();
builder.Services.AddScoped<UserRepository>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
