using ClienteWebAPI.DAL;
using ClienteWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClienteWebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly MyAppDbContext _context;

        public ClienteController(MyAppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var clientes = _context.Cliente.ToList();
                if (clientes.Count == 0)
                {
                    return NotFound("No hay clientes registrados.");
                }
                return Ok(clientes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id) 
        {
            try
            {
                var cliente = _context.Cliente.Find(id);
                if (cliente == null)
                {
                    return NotFound($"Cliente con el ID \"{id}\" no encontrado.");
                }
                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Post (Cliente model)
        {
            try
            {
                _context.Add(model);
                _context.SaveChanges();
                return Ok("Cliente creado.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult Put(Cliente model)
        {
            if(model == null || model.IdCliente == 0)
            {
                if(model == null)
                {
                    return BadRequest("La data del modelo es inválida.");
                }
                else if (model.IdCliente == 0)
                {
                    return BadRequest($"El cliente con el ID \"{model.IdCliente}\" es inválido.");
                }
            }
            try
            {
                var cliente = _context.Cliente.Find(model.IdCliente);
                if (cliente == null)
                {
                    return NotFound($"El cliente con el ID \"{model.IdCliente}\" no fue encontrado.");
                }
                cliente.TipoDocumento = model.TipoDocumento;
                cliente.Documento = model.Documento;
                cliente.NombreCompleto = model.NombreCompleto;
                cliente.Correo = model.Correo;
                cliente.Estado = model.Estado;
                cliente.FechaCreacion = model.FechaCreacion;
                _context.SaveChanges();
                return Ok("Los datos del Cliente fueron actualizados.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public IActionResult Delete(int IdCliente)
        {
            try
            {
                var cliente = _context.Cliente.Find(IdCliente);
                if (cliente == null)
                {
                    return NotFound($"El Cliente con el ID \"{IdCliente}\" no fue encontrado.");
                }
                _context.Cliente.Remove(cliente);
                _context.SaveChanges();
                return Ok("Cliente eliminado.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
