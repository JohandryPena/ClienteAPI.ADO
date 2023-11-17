using Client.Application.Interfaces;
using Client.Domain;
using Client.Domain.DTOs;
using Client.Infrastructure.DBContext;
using Client.Infrastructure.Validation;
using Microsoft.EntityFrameworkCore;

namespace Client.Infrastructure.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ClienteDbContext _clienteDbContext;
        private readonly ClienteValidation _clienteValidation;

        public ClienteRepository(ClienteDbContext clienteDbContext, ClienteValidation clienteValidation)
        {
            _clienteDbContext = clienteDbContext;
            _clienteValidation = clienteValidation;
        }
        public async Task<List<Cliente>> GetAllClientesAsync(int pagina, int noRegistro)
        {
            int skip = (pagina-1) * noRegistro;
            return await _clienteDbContext.Clientes
           .Where(c => c.Estado == true )
           .OrderBy(c => c.ClienteId)  
           .Skip(skip)
           .Take(noRegistro)
           .ToListAsync();
        }
        public async Task<string> CreateClienteAsync(Cliente cliente)
        {
            var validationResult = _clienteValidation.ClienteValidationResult(cliente);

            switch (true)
            {
                case var _ when !validationResult.IsValid:
                    var errores = validationResult.Errors.Select(error => $" - {error.ErrorMessage}");
                    return string.Join(Environment.NewLine, errores);

                case var _ when await _clienteDbContext.Clientes.AnyAsync
                    (c => c.Persona.Identificacion == cliente.Persona.Identificacion):
                    return "El usuario ya existe.";

                default:
                    _clienteDbContext.Clientes.Add(cliente);
                    await _clienteDbContext.SaveChangesAsync();
                    return "Registro Exitoso";
            }
        }

        public async Task<string> DeleteClienteAsync(int Id)
        {
            try
            {
                var cliente = await _clienteDbContext.Clientes.FindAsync(Id);
                if (cliente != null)
                {
                    cliente.Estado = false;
                    await _clienteDbContext.SaveChangesAsync();
                    return "Registro Elimiado";
                }
                return "Registro No Existe";
            }
            catch (Exception)
            {
                throw;
            } 
        }

        public async Task<Cliente> GetClienteAsync(int Id)
        {
            return await _clienteDbContext.Clientes.FirstOrDefaultAsync
                (c => c.ClienteId == Id && c.Estado == true);
        }

        public async Task<string> UpdateClienteAsync(int Id, Cliente cliente)
        {
            var existingCliente = await _clienteDbContext.Clientes.FindAsync(Id);
            var valido = _clienteValidation.ClienteValidationResult(cliente);

            if (existingCliente != null && valido.IsValid)
            {
                existingCliente.Persona=cliente.Persona;
                existingCliente.Contraseña=cliente.Contraseña;
                existingCliente.ImagenBase64= cliente.ImagenBase64;
               
                await _clienteDbContext.SaveChangesAsync();
           
                return "Registro Actualizado";
            }
            else 
            {
                var errores = valido.Errors.Select(error => $" - {error.ErrorMessage}");
                string mensaje = string.Join(Environment.NewLine, errores);
                return mensaje;
            }
     
        }

    }
}
