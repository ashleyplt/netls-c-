using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Ordenes
{
    public class OrdenesDto
    {
        public Guid IdOrden { get; set; }
        public string NOrden { get; set; }
        public Guid IdtblMedico { get; set; }
        public Guid IdPaciente { get; set; }
        public Guid IdTipoServicio { get; set; }
        public Guid IdTipoOrden { get; set; }
        public string Asistencia { get; set; }
        public string Observaciones { get; set; }
        public DateTime FechaOrden { get; set; }
        public string Activo { get; set; }
        public DateTime? FechaImprime { get; set; }
        public string UsuarioImprime { get; set; }
        public int Estado { get; set; }
        public string Finalizado { get; set; }
        public DateTime? FechaCita { get; set; }
        public DateTime FechaPreporte { get; set; }

        public string TipoServicio { get; set; }

        public virtual ICollection<OrdenesDetalleDto> OrdenesDetallesLink { get; set; }
    }
}
