using Integrador.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrador.Shared.ViewModels
{
    public class EmpresaViewModel
    {
        public Empresa EmpresaToRegistry { get; set; }
        public List<Empresa> Empresas { get; set; }
    }
}
