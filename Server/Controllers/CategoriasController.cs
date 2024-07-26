using Integrador.Server.Data;
using Integrador.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Integrador.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly TestContext _context;
        private readonly ILogger<CategoriasController> _logger;

        public CategoriasController(TestContext context, ILogger<CategoriasController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(Categoria categoria)
        {
            if (categoria == null)
            {
                return BadRequest();
            }

            await _context.Categoria.AddAsync(categoria);
            var response = await _context.SaveChangesAsync();
            if (response > 0)
            {
                return Ok(categoria);
            }

            return BadRequest();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var activeCat = await _context.Categoria.Where(u => u.Estado == "Activo").ToListAsync();
            if (activeCat == null || activeCat.Count == 0)
            {
                return NotFound("No active users found.");
            }

            return Ok(activeCat);
        }

        [HttpPut("Deactivate/{id}")]
        public async Task<IActionResult> Deactivate(int id)
        {
            var categoria = await _context.Categoria.FindAsync(id);
            if (categoria == null)
            {
                return NotFound("Category not found.");
            }

            // Cambia el estado a "Inactivo"
            categoria.Estado = "Inactivo";

            _context.Categoria.Update(categoria);
            await _context.SaveChangesAsync();

            return Ok(categoria);
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(int id, Categoria categoria)
        {
            if (id != categoria.IdCategoria)
            {
                _logger.LogWarning("Category ID mismatch. Provided ID: {id}, Category ID: {categoryId}.", id, categoria.IdCategoria);
                return BadRequest("Category ID mismatch.");
            }

            try
            {
                var existingCategoria = await _context.Categoria.FindAsync(id);
                if (existingCategoria == null)
                {
                    return NotFound("Category not found.");
                }

                existingCategoria.Nombre = categoria.Nombre;
                existingCategoria.FechaCreacion = categoria.FechaCreacion;
                existingCategoria.Estado = categoria.Estado;

                _context.Categoria.Update(existingCategoria);
                await _context.SaveChangesAsync();

                return Ok(existingCategoria);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating category with ID {id}.", id);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
