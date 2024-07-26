using Integrador.Server.Data;
using Integrador.Shared.Entities;
using Integrador.Shared.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Integrador.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly TestContext _context;

        public AuthController(TestContext context)
        {
            _context = context;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _context.Usuario
                .FirstOrDefaultAsync(u => u.Correo == loginModel.Correo);

            if (user == null || user.Clave != loginModel.Clave)
            {
                return Unauthorized("Correo o clave incorrecta.");
            }

            // Aquí puedes agregar lógica para generar y devolver un token JWT si es necesario

            return Ok(user);
        }
    }
}
