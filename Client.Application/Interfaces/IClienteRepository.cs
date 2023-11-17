using Client.Domain;
using Client.Domain.DTOs;

namespace Client.Application.Interfaces
{
    public interface IClienteRepository
    {
        Task<List<Cliente>> GetAllClientesAsync(int pagina, int noRegistro);
        Task<string> CreateClienteAsync(Cliente cliente);
        Task<Cliente> GetClienteAsync(int Id);
        Task<string> DeleteClienteAsync(int Id);
        Task<string> UpdateClienteAsync(int Id, Cliente cliente);

    }
}
