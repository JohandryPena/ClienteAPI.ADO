using Client.Domain;
using Client.Domain.DTOs;

namespace Client.Application.Interfaces
{
    public interface IClienteService
    {
        Task<List<ClienteDTO>> GetAllClientesAsync(int pagina, int noRegistro);
        Task<string> CreateClienteAsync(ClienteDTO cliente);
        Task<ClienteDTO> GetClienteAsync(int Id);
        Task<string> DeleteClienteAsync(int Id);
        Task<string> UpdateClienteAsync(int Id, ClienteDTO cliente);
    }
}
