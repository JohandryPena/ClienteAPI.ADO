using Client.Domain;
using Client.Domain.DTOs;

namespace Client.Application.Interfaces
{
    public interface ISeccionRepository
    {
        Task<Cliente> Loging(Cliente cliente);
        Task<string> RegistrarCliente(Cliente cliente);
        string GetToken(Cliente cliente);

    }
}
