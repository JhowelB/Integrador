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
    public class EmpresasController : ControllerBase
    {
        private readonly TestContext _context;
        private readonly ILogger<EmpresasController> _logger;

        public EmpresasController(TestContext context, ILogger<EmpresasController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(Empresa empresa)
        {
            if (empresa == null)
            {
                return BadRequest();
            }

            await _context.Empresa.AddAsync(empresa);
            var response = await _context.SaveChangesAsync();
            if (response > 0)
            {
                return Ok(empresa);
            }

            return BadRequest();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var activeEmpresas = await _context.Empresa.Where(e => e.Estado == "Activo").ToListAsync();
            if (activeEmpresas == null || activeEmpresas.Count == 0)
            {
                return NotFound("No active companies found.");
            }

            return Ok(activeEmpresas);
        }

        [HttpPut("Deactivate/{id}")]
        public async Task<IActionResult> Deactivate(int id)
        {
            var empresa = await _context.Empresa.FindAsync(id);
            if (empresa == null)
            {
                return NotFound("Company not found.");
            }

            // Cambia el estado a "Inactivo"
            empresa.Estado = "Inactivo";

            _context.Empresa.Update(empresa);
            await _context.SaveChangesAsync();

            return Ok(empresa);
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(int id, Empresa empresa)
        {
            if (id != empresa.IdEmpresa)
            {
                _logger.LogWarning("Company ID mismatch. Provided ID: {id}, Company ID: {companyId}.", id, empresa.IdEmpresa);
                return BadRequest("Company ID mismatch.");
            }

            try
            {
                var existingEmpresa = await _context.Empresa.FindAsync(id);
                if (existingEmpresa == null)
                {
                    return NotFound("Company not found.");
                }

                existingEmpresa.NombreEmpresa = empresa.NombreEmpresa;
                existingEmpresa.Usuario = empresa.Usuario;
                existingEmpresa.Clave = empresa.Clave;
                existingEmpresa.RUC = empresa.RUC;
                existingEmpresa.Direccion = empresa.Direccion;
                existingEmpresa.Telefono = empresa.Telefono;
                existingEmpresa.Correo = empresa.Correo;
                existingEmpresa.FraseSecreta = empresa.FraseSecreta;
                existingEmpresa.NumeroTrabajadores = empresa.NumeroTrabajadores;
                existingEmpresa.Estado = empresa.Estado;

                _context.Empresa.Update(existingEmpresa);
                await _context.SaveChangesAsync();

                return Ok(existingEmpresa);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating company with ID {id}.", id);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
