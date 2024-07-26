using Integrador.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrador.Shared.ViewModels
{
    public class CategoriaViewModel
    {
        public Categoria CategoriaToRegistry { get; set; }
        public List<Categoria> Categorias { get; set; }
    }
}

