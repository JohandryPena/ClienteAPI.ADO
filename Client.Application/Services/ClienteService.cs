using Client.Application.Interfaces;
using Client.Application.Mapper;
using Client.Domain;
using Client.Domain.DTOs;

namespace Client.Application.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly ClienteMapper _clienteMapper;
        public ClienteService(IClienteRepository movieRepository, ClienteMapper clienteMapper)
        {
            _clienteRepository = movieRepository;
            _clienteMapper = clienteMapper;

        }
        public async Task<List<ClienteDTO>> GetAllClientesAsync(int pagina, int noRegistro)
        {
        
            return _clienteMapper.MapListToDto(
                await _clienteRepository.GetAllClientesAsync(pagina, noRegistro)); ;
        }
        public async Task<string> CreateClienteAsync(ClienteDTO cliente)
        {
            return await _clienteRepository.CreateClienteAsync
                (_clienteMapper.MapToEntity(cliente));
        }

        public async Task<string> DeleteClienteAsync(int Id)
        {
           return await _clienteRepository.DeleteClienteAsync(Id);
        }

        public async Task<ClienteDTO> GetClienteAsync(int Id)
        {
            return _clienteMapper.MapToDto(await _clienteRepository.GetClienteAsync(Id));
        }

        public async Task<string> UpdateClienteAsync(int Id, ClienteDTO cliente)
        {
            return await _clienteRepository.UpdateClienteAsync(Id, _clienteMapper.MapToEntity(cliente));
        }
    }
}
