using System.ComponentModel.DataAnnotations;

namespace Integrador.Shared.Entities
{
    public class Usuario
    {
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "Nombres es requerido.")]
        [StringLength(50, ErrorMessage = "Nombres no puede exceder los 50 caracteres.")]
        public string Nombres { get; set; }

        [Required(ErrorMessage = "Apellidos es requerido.")]
        [StringLength(50, ErrorMessage = "Apellidos no puede exceder los 50 caracteres.")]
        public string Apellidos { get; set; }

        public int? Cedula { get; set; }

        public int? Telefono { get; set; }

        [Required(ErrorMessage = "Correo es requerido.")]
        [EmailAddress(ErrorMessage = "Correo no es válido.")]
        public string Correo { get; set; }

        [Required(ErrorMessage = "Clave es requerida.")]
        [StringLength(50, ErrorMessage = "Clave no puede exceder los 50 caracteres.")]
        public string Clave { get; set; }

        [Required(ErrorMessage = "Rol es requerido.")]
        [StringLength(50, ErrorMessage = "Rol no puede exceder los 50 caracteres.")]
        public string Rol { get; set; }

        [Required(ErrorMessage = "Fecha de Creación es requerida.")]
        public DateTime FechaCreacion { get; set; }

        [Required(ErrorMessage = "Estado es requerido.")]
        [StringLength(10, ErrorMessage = "Estado no puede exceder los 10 caracteres.")]
        public string Estado { get; set; }

        [StringLength(100, ErrorMessage = "Estudios no puede exceder los 100 caracteres.")]
        public string Estudios { get; set; }

        public int? Edad { get; set; }

        [StringLength(100, ErrorMessage = "Idiomas no puede exceder los 100 caracteres.")]
        public string Idiomas { get; set; }

        [StringLength(100, ErrorMessage = "Experiencia no puede exceder los 100 caracteres.")]
        public string Experiencia { get; set; }

        [StringLength(100, ErrorMessage = "Habilidades no puede exceder los 100 caracteres.")]
        public string Habilidades { get; set; }
    }
}
