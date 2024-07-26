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
    public class UsersController : ControllerBase
    {
        private readonly TestContext _context;
        private readonly ILogger<UsersController> _logger;

        public UsersController(TestContext context, ILogger<UsersController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(Usuario user)
        {
            if (user == null)
            {
                return BadRequest();
            }

            await _context.AddAsync(user);
            var response = await _context.SaveChangesAsync();
            if (response > 0)
            {
                return Ok(user);
            }

            return BadRequest();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var activeUsers = await _context.Usuario.Where(u => u.Estado == "Activo").ToListAsync();
            if (activeUsers == null || activeUsers.Count == 0)
            {
                return NotFound("No active users found.");
            }

            return Ok(activeUsers);
        }

        [HttpPut("Deactivate/{id}")]
        public async Task<IActionResult> Deactivate(int id)
        {
            var user = await _context.Usuario.FindAsync(id);
            if (user == null)
            {
                return NotFound("User not found.");
            }

            // Cambia el estado a "Inactivo"
            user.Estado = "Inactivo";

            // Marca el usuario como modificado
            _context.Usuario.Update(user);

            // Guarda los cambios en la base de datos
            await _context.SaveChangesAsync();

            return Ok(user);
        }
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(int id, Usuario user)
        {
            if (id != user.IdUsuario)
            {
                _logger.LogWarning("User ID mismatch. Provided ID: {id}, User ID: {userId}.", id, user.IdUsuario);
                return BadRequest("User ID mismatch.");
            }

            try
            {
                var existingUser = await _context.Usuario.FindAsync(id);
                if (existingUser == null)
                {
                    return NotFound("User not found.");
                }

                existingUser.Nombres = user.Nombres;
                existingUser.Apellidos = user.Apellidos;
                existingUser.Cedula = user.Cedula;
                existingUser.Telefono = user.Telefono;
                existingUser.Correo = user.Correo;
                existingUser.Clave = user.Clave;
                existingUser.Rol = user.Rol;
                existingUser.Estado = user.Estado;
                existingUser.Estudios = user.Estudios;
                existingUser.Edad = user.Edad;
                existingUser.Idiomas = user.Idiomas;
                existingUser.Experiencia = user.Experiencia;
                existingUser.Habilidades = user.Habilidades;

                _context.Usuario.Update(existingUser);
                await _context.SaveChangesAsync();

                return Ok(existingUser);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating user with ID {id}.", id);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
