using Client.Domain;
using Client.Domain.DTOs;

namespace Client.Application.Interfaces
{

    //This is a use case
    public interface ISeccionService
    {
        Task<Cliente> Loging(Cliente cliente);
        Task<string> RegistrarCliente(ClienteDTO cliente);
        string GetToken(Cliente cliente);

    }
}
