using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Sahadan.Application.Abstract;
using Sahadan.Application.Concrete;
using Sahadan.Application.MappingProfiles;
using Sahadan.DataAccess.Abstract;
using Sahadan.DataAccess.Concrete.EntityFrameWork;
using Sahadan.DataAccess.Concrete.EntityFrameWork.Contexts;
using Sahadan.Entities.Utilities.Security.Encrption;
using Sahadan.Entities.Utilities.Security.JWT;
using Sahadan.Application.DependencyResolvers.Service;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;
var tokenOptions = config.GetSection("TokenOptions").Get<TokenOptions>();
// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidIssuer = tokenOptions.Issuer,
                        ValidAudience = tokenOptions.Audience,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
                    };
                });
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new() { Title = "Sahadan.WebAPI", Version = "v1" });
    var jwtSecurityScheme = new OpenApiSecurityScheme
    {
        Scheme = "Bearer",
        BearerFormat = "JWT",
        Name = "JWT Authentication",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Description = "Paste your JWT Bearer token on textbox below!",

        Reference = new OpenApiReference
        {
            Id = JwtBearerDefaults.AuthenticationScheme,
            Type = ReferenceType.SecurityScheme
        }
    };
    options.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                { jwtSecurityScheme, Array.Empty<string>() }
            });
});
builder.Services.AddSahadanServices();
/*// Register repositories
builder.Services.AddScoped<ICountryRepository, CountryRepository>();
builder.Services.AddScoped<ILegueRepository, LegueRepository>();
builder.Services.AddScoped<IPlayerRepository, PlayerRepository>();
builder.Services.AddScoped<ITeamRepository, TeamRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ITokenHelper, JwtHelper>();
builder.Services.AddScoped<IUserRoleRepository, UserRoleRepository>();

// Register services
builder.Services.AddScoped<ICountryService, CountryService>();
builder.Services.AddScoped<ILegueService, LegueService>();
builder.Services.AddScoped<IPlayerService, PlayerService>();
builder.Services.AddScoped<ITeamService, TeamService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IUserRoleService, UserRoleService>();*/

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
    app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "Sahadan"); });
}

app.UseHttpsRedirection();
app.UseCors("MyPolicy");


app.UseAuthentication();

app.UseAuthorization();
app.MapControllers(); // Map all controllers in the application

app.Run();
