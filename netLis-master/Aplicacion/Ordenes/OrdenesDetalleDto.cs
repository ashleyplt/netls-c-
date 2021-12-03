using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Ordenes
{
    public class OrdenesDetalleDto
    {
        public Guid IdOrdenDetalle { get; set; }
        public Guid IdOrden { get; set; }
        public string NOrden { get; set; }
        public Guid IdExamen { get; set; }
        public string Activo { get; set; }
    }
}
