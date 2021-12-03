using Dominio.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.AreaLabServicio
{
    public class Editar
    {
        public class Ejecuta : IRequest
        {
            public Guid IdAreaLabServicio { get; set; }
            public string Descripcion { get; set; }
        }
        public class Manejador : IRequestHandler<Ejecuta>
        {
            private readonly netLisContext _context;
            public Manejador(netLisContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var arealab_serv = await _context.TblCatAreasLabServicios.FindAsync(request.IdAreaLabServicio);
                if (arealab_serv == null)
                {
                    throw new Exception("El area de laboratorio de servicio no está en el sistema");
                }

                arealab_serv.Descripcion = request.Descripcion ?? arealab_serv.Descripcion;

                var resultado = await _context.SaveChangesAsync();
                if (resultado > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("Error al modificar el area de laboratorio de servicio");
            }

        }
    }
}
