using Client.Application.Interfaces;
using Client.Domain;
using Client.Domain.DTOs;
using Client.Infrastructure.DBContext;
using Client.Infrastructure.Validation;
using FluentValidation.Internal;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Client.Infrastructure.Repository
{
    public class SeccionRepository : ISeccionRepository
    {
        private readonly ClienteDbContext _clienteDbContext;
        private readonly LoginValidation _loginValidation;
        private readonly ClienteValidation _clienteValidation;
        private IConfiguration _config;

        public SeccionRepository(ClienteDbContext clienteDbContext, IConfiguration config, LoginValidation loginValidation, ClienteValidation clienteValidation)
        {
            _clienteDbContext = clienteDbContext;
            _config = config;
            _loginValidation=loginValidation;
            _clienteValidation=clienteValidation;
        }

        public string GetToken(Cliente client)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
             {
                new Claim("ClienteId", client.ClienteId.ToString())
            };

            var token = new JwtSecurityToken(
                _config["Jwt:Issuer"],        
                _config["Jwt:Issuer"],      
                claims,                        
                expires: DateTime.Now.AddMinutes(120), 
                signingCredentials: credentials  
            );
         
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<Cliente> Loging(Cliente cliente)
        {
            var valido = _loginValidation.Validate(cliente);
            if (valido.IsValid)
            {
                return await _clienteDbContext.Clientes.FirstOrDefaultAsync(c => c.Contraseña == cliente.Contraseña
               && c.Persona.Identificacion==cliente.Persona.Identificacion
               && c.Estado == true);
            }
            return null;
               
        }

        public async Task<string> RegistrarCliente(Cliente cliente)
        {
            var validationResult = _clienteValidation.ClienteValidationResult(cliente);

            switch (true)
            {
                case var _ when !validationResult.IsValid:
                    var errores = validationResult.Errors.Select(error => $" - {error.ErrorMessage}");
                    return string.Join(Environment.NewLine, errores);

                case var _ when await _clienteDbContext.Clientes.AnyAsync(c => c.Persona.Identificacion == cliente.Persona.Identificacion):
                    return "El usuario ya existe.";

                default:
                    _clienteDbContext.Clientes.Add(cliente);
                    await _clienteDbContext.SaveChangesAsync();
                    return "Registro Exitoso";
            }
        }
    }
}
