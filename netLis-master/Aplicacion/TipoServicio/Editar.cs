using Dominio.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.TipoServicio
{
    public class Editar
    {
        public class Ejecuta : IRequest
        {
            public Guid IdTipoServicio { get; set; }
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
                var tipo_servicio = await _context.TblCatTipoServicios.FindAsync(request.IdTipoServicio);
                if (tipo_servicio == null)
                {
                    throw new Exception("El tipo de servicio no está en el sistema");
                }

                tipo_servicio.Descripcion = request.Descripcion ?? tipo_servicio.Descripcion;

                var resultado = await _context.SaveChangesAsync();
                if (resultado > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("Error al modificar el tipo de servicio");
            }

        }
    }
}
