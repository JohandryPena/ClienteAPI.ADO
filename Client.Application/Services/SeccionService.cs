using Client.Application.Interfaces;
using Client.Application.Mapper;
using Client.Domain;
using Client.Domain.DTOs;

namespace Client.Application.Services
{
    public class SeccionService : ISeccionService
    {
        private readonly ISeccionRepository _SeccionRepository;
        private readonly ClienteMapper _clienteMapper;
        public SeccionService(ISeccionRepository SeccionRepository, ClienteMapper clienteMapper)
        {
            _SeccionRepository = SeccionRepository;
            _clienteMapper = clienteMapper;
        }

        public string GetToken(Cliente cliente)
        {
            return _SeccionRepository.GetToken(cliente);
        }

        public async Task<Cliente> Loging(Cliente cliente)
        {
          return await _SeccionRepository.Loging(cliente);
        }

        public async Task<string> RegistrarCliente(ClienteDTO cliente)
        {
            return await _SeccionRepository.RegistrarCliente
                (_clienteMapper.MapToEntity(cliente));
        }
    }
}
