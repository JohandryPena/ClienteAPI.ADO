using Client.Application.Interfaces;
using Client.Application.Mapper;
using Client.Application.Services;
using Client.Infrastructure.DBContext;
using Client.Infrastructure.Repository;
using Client.Infrastructure.Validation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager configuration = builder.Configuration;

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Add Token 
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
  .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = configuration.GetSection("Jwt:Issuer").Value,
            ValidAudience = configuration.GetSection("Jwt:Issuer").Value,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetSection("Jwt:Key").Value))
        };
    });
//Add Database Service
builder.Services.AddDbContext<ClienteDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
     b => b.MigrationsAssembly("Client.API")));

//Inyeccion de Dependencias 
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();

builder.Services.AddScoped<ISeccionService, SeccionService>();
builder.Services.AddScoped<ISeccionRepository, SeccionRepository>();
builder.Services.AddScoped<LoginValidation>();
builder.Services.AddScoped<ClienteValidation>();
builder.Services.AddScoped<ClienteMapper>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(x => x.AllowAnyHeader()
      .AllowAnyMethod().AllowAnyOrigin());
    
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();




app.Run();
