using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrador.Shared.Entities
{
    public class Empresa
    {
        public int IdEmpresa { get; set; }
        public string NombreEmpresa { get; set; }
        public string Usuario { get; set; }
        public string Clave { get; set; }
        public long RUC { get; set; }
        public string Direccion { get; set; }
        public long Telefono { get; set; }
        public string Correo { get; set; }
        public string FraseSecreta { get; set; }
        public int NumeroTrabajadores { get; set; }
        public string Estado { get; set; }
    }
}
