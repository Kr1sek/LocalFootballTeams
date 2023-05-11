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

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(c =>
{
    c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});
builder.Services.AddControllers().AddFluentValidation();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ITeamService, TeamService>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
builder.Services.AddScoped <IValidator<RegisterUserDto>,RegisterUserDtoValidator>();
builder.Services.AddDbContext<DbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(Directory.GetCurrentDirectory(), "Logos")),
    RequestPath = "/Logos"
});

app.Run();
