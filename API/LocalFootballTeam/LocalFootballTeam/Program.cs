using LocalFootballTeam.Services.Services;
using LocalFootballTeam.Services.Interfaces;
using LocalFootballTeam.Migrations;
using Microsoft.Extensions.FileProviders;
using Microsoft.AspNetCore.Identity;
using LocalFootballTeam.Models.Models;
using FluentValidation;
using LocalFootballTeam.Models.Validators;
using FluentValidation.AspNetCore;
using LocalFootballTeam.Models.Dtos;
using LocalFootballTeam;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using LocalFootballTeam.Interfaces;
using LocalFootballTeam.Services;

var builder = WebApplication.CreateBuilder(args);
var autheticationSettings = new AutheticationSettings();

// Add services to the container.
builder.Services.AddCors(c =>
{
    c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});
builder.Services.AddControllers();
builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ITeamService, TeamService>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
builder.Services.AddScoped <IValidator<RegisterUserDto>,RegisterUserDtoValidator>();
builder.Services.AddDbContext<DbContext>();
builder.Configuration.GetSection("Authentication").Bind(autheticationSettings);
builder.Services.AddSingleton(autheticationSettings);

builder.Services.AddAuthentication(option =>
{
    option.DefaultAuthenticateScheme = "Bearer";
    option.DefaultScheme = "Bearer";
    option.DefaultChallengeScheme = "Bearer";
}).AddJwtBearer(cfg =>
{
    cfg.RequireHttpsMetadata = false;
    cfg.SaveToken = true;
    cfg.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = autheticationSettings.JwtIssuer,
        ValidAudience = autheticationSettings.JwtIssuer,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(autheticationSettings.JwtKey))
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseAuthentication();

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseAuthorization();

app.MapControllers();

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(Directory.GetCurrentDirectory(), "Logos")),
    RequestPath = "/Logos"
});

app.Run();
