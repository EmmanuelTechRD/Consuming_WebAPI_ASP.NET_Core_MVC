using CategoriaWebAPI.DAL;
using CategoriaWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace CategoriaWebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly MyAppDbContext _context;

        public CategoriaController(MyAppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var categorias = _context.Categoria.ToList();
                if (categorias.Count == 0)
                {
                    return NotFound("Categorias no encontradas.");
                }
                return Ok(categorias);
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
                var categoria = _context.Categoria.Find(id);
                if (categoria == null)
                {
                    return NotFound($"Categoria con el ID #{id} no encontrada.");
                }
                return Ok(categoria);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Post (Categoria model)
        {
            try
            {
                _context.Add(model);
                _context.SaveChanges();
                return Ok("Categoria creada.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult Put(Categoria model)
        {
            if(model == null || model.IdCategoria == 0)
            {
                if(model == null)
                {
                    return BadRequest("La data del modelo es inválida.");
                }
                else if (model.IdCategoria == 0)
                {
                    return BadRequest($"La categoria con el ID #{model.IdCategoria} es inválida.");
                }
            }
            try
            {
                var categoria = _context.Categoria.Find(model.IdCategoria);
                if (categoria == null)
                {
                    return NotFound($"La categoria con el ID #{model.IdCategoria} no fue encontrada.");
                };
                categoria.Descripcion = model.Descripcion;
                categoria.Estado = model.Estado;
                categoria.FechaCreacion = model.FechaCreacion;
                _context.SaveChanges();
                return Ok("Los detalles de la Categoria fueron actualizados.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public IActionResult Delete(int IdCategoria)
        {
            try
            {
                var categoria = _context.Categoria.Find(IdCategoria);
                if (categoria == null)
                {
                    return NotFound($"La categoria con el ID #{IdCategoria} no fue encontrada.");
                }
                _context.Categoria.Remove(categoria);
                _context.SaveChanges();
                return Ok("Categoria eliminada.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
