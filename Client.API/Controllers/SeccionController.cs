using Client.Application.Interfaces;
using Client.Domain;
using Client.Domain.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Client.API.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class SeccionController : ControllerBase
    {
        private readonly ISeccionService _seccionService;

        public SeccionController(ISeccionService seccionService)
        {           
            _seccionService=seccionService; 
        }
       
        [Route("Login")]
        [HttpPost]
        public async Task<ActionResult<Cliente>> GetAsync([FromBody]  Cliente login)
        {
            Cliente cliente = await _seccionService.Loging(login);
            if (cliente!=null )
                return Ok(new{Mensaje="Seccion Valida",Token=_seccionService.GetToken(cliente)});
            return Ok(new {Mensaje="Invalid User"});
        }
      
        [Route("Signup")]
        [HttpPost]
        public async Task<ActionResult<ClienteDTO>> PostClienteAsync([FromBody] ClienteDTO cliente)
        {
            if (cliente !=null)
               return Ok(new { Mensaje = await _seccionService.RegistrarCliente(cliente) });
            return BadRequest(new {Mensaje="Algo Salio Mal"});
            
        }
    }
}
