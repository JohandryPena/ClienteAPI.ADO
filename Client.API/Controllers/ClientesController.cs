using Client.Application.Interfaces;
using Client.Domain;
using Client.Domain.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Client.API.Controllers
{   [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteService _service;

        public ClientesController(IClienteService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<ClienteDTO>>> GetAsync(int pagina, int noRegistro)
        {
            List<ClienteDTO> regsitros = await _service.GetAllClientesAsync(pagina, noRegistro);
            return Ok(new { TotalRegistros= 10, regsitros });
        }

        [Route("logueado")]
        [HttpGet]
        public async Task<ActionResult<ClienteDTO>> GetByIdAsync()
        {  
            try
            {
                int id = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type=="ClienteId").Value);
                ClienteDTO cliente = await _service.GetClienteAsync(id);

                if (cliente == null)
                    return Ok(new { Mensaje = "No se encontro Registro" });
             
                return Ok(cliente);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClienteDTO>> GetByIdAsync(int id)
        {
            try
            {
                ClienteDTO cliente = await _service.GetClienteAsync(id);

                if (cliente == null)
                    return Ok(new { Mensaje = "No se encontro Registro" });
                
                return Ok(cliente);
            }
            catch (Exception)
            {
                throw;
            }

        }

        [HttpPost]
        public async Task<ActionResult<string>> PostClienteAsync(ClienteDTO clienteDto)
        {
            return Ok(new { Mensaje = await _service.CreateClienteAsync(clienteDto) });
        }

        [HttpPut("{Id}")]
        public async Task<ActionResult<string>> PutAsync(int Id,ClienteDTO cliente)
        {
            return Ok(new { Mensaje = await _service.UpdateClienteAsync(Id, cliente) });
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult<string>> DeleteAsync(int Id)
        {
            return Ok(new { Mensaje = await _service.DeleteClienteAsync(Id)});
        }


    }
}
