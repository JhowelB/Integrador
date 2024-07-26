using Integrador.Shared.Entities;
using System.Collections.Generic;

namespace Integrador.Shared.ViewModels
{
    public class UserViewModel
    {
        public Usuario UserToRegistry { get; set; } = new Usuario();
        public List<Usuario> Users { get; set; } = new List<Usuario>();
    }
}
