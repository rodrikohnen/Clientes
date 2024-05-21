using Clientes.BLL;
using Clientes.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Clientes.APIWEB.Controllers
{

    [Route("api/[controller]/[action]")]
    [Produces("application/json")]
    [ApiController]
    public class ClienteController: ControllerBase
    {
        private readonly IClienteServicio _clienteServicio;

        public ClienteController(IClienteServicio clienteServicio)
        {
            _clienteServicio = clienteServicio;
        }     


        [HttpGet("BusquedaXID")]
        public async Task<ActionResult<MostrarClienteDTO>> ListarporID(int id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var cliente = await _clienteServicio.ObtenerPorId(id);

                    return Ok(cliente);
                }
                catch (NotFoundException ex)
                {
                    return NotFound(ex.Message);
                }
                catch (Exception)
                {
                    return StatusCode(500, "Error interno del servidor");
                }

            }else return BadRequest();
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<MostrarClienteDTO>> Obtenertodos()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var clientes = await _clienteServicio.ObtenerTodos();
                    return Ok(clientes);
                }
                catch (Exception)
                {
                    return StatusCode(500, "Error interno del servidor");
                }

            }else return BadRequest();
        }


        [HttpPost("Registrar")]
        public async Task<ActionResult<MostrarClienteDTO>> Registrar([FromForm] CreacionClienteDTO creacionCliente)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var cliente = await _clienteServicio.Registrar(creacionCliente);

                    return Ok(cliente);
                }
                catch (Exception)
                {
                    return StatusCode(500, "Error interno del servidor");
                }

            } else return BadRequest();

        }

    
        [HttpPut("Actualizar")]
        public async Task<ActionResult<MostrarClienteDTO>> Actualizar(int id, CreacionClienteDTO modelo)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var cliente = await _clienteServicio.Actualizar(id, modelo);

                    return Ok(cliente);
                }
                catch (NotFoundException ex)
                {
                    return NotFound(ex.Message);
                }
                catch (Exception)
                {
                    return StatusCode(500, "Error interno del servidor");
                }

            }else return BadRequest();
        }

        
        [HttpDelete("Eliminar")]
        public async Task<IActionResult> Eliminar(int id)
        {
            if (ModelState.IsValid)
            {

                try
                {
                    var resultado = await _clienteServicio.Eliminar(id);

                    return NoContent();
                }
                catch (NotFoundException ex)
                {
                    return NotFound(ex.Message);
                }
                catch (Exception)
                {
                    return StatusCode(500, "Error interno del servidor");
                }

            }else return BadRequest();
        }
        
    }

}

