using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Ordenes
{
    public class ExamenDto
    {
        public Guid IdExamen { get; set; }
        public Guid IdAreaLabServicio { get; set; }
        public Guid IdCategoriaExamenes { get; set; }
        public Guid IdTipoMuestrad { get; set; }
        public Guid IdUnidadMedidas { get; set; }
        public Guid IdTipoResultado { get; set; }
        public string Descripcion { get; set; }
        public string DescripcionCorta { get; set; }
        public string Confidencial { get; set; }
        public int Estado { get; set; }

        public virtual ICollection<OrdenesDetalleDto> OrdenesDetallesLink { get; set; }
    }
}
