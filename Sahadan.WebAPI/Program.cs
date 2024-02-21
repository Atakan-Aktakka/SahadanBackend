using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Sahadan.Application.Abstract;
using Sahadan.Application.Concrete;
using Sahadan.Application.MappingProfiles;
using Sahadan.DataAccess.Abstract;

using Sahadan.DataAccess.Concrete.EntityFrameWork;
using Sahadan.DataAccess.Concrete.EntityFrameWork.Contexts;
using Sahadan.WebAPI.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register repositories
builder.Services.AddScoped<ICountryRepository, CountryRepository>();
builder.Services.AddScoped<ILegueRepository, LegueRepository>();
builder.Services.AddScoped<IPlayerRepository, PlayerRepository>();
builder.Services.AddScoped<ITeamRepository, TeamRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

// Register services
builder.Services.AddScoped<ICountryService, CountryService>();
builder.Services.AddScoped<ILegueService, LegueService>();
builder.Services.AddScoped<IPlayerService, PlayerService>();
builder.Services.AddScoped<ITeamService, TeamService>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddAutoMapper(typeof(IMappingProfilesMarker));
builder.Services.AddCors();
// Add DbContext
builder.Services.AddDbContext<SahadanContext>();
builder.Services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
{
    builder.WithOrigins("*")
           .AllowAnyMethod()
           .AllowAnyHeader();
}));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("MyPolicy");
app.MapControllers(); // Map all controllers in the application

app.Run();
