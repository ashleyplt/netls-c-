using Dominio.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.OrdenDetalles
{
    public class Nuevo
    {
        public class Ejecuta : IRequest
        {
            public Guid IdOrden { get; set; }
            public string NOrden { get; set; }
            public Guid IdExamen { get; set; }
            public string Activo { get; set; }
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
                var orden_detalle = new TblOrdenesDetalle
                {
                    IdOrdenDetalle = new Guid(),
                    IdOrden = request.IdOrden,
                    NOrden = request.NOrden,
                    IdExamen = request.IdExamen,
                    Activo = request.Activo,
                };

                _context.TblOrdenesDetalles.Add(orden_detalle);
                var valor = await _context.SaveChangesAsync();
                if (valor > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("No se pudo guardar el tipo de orden");
            }
        }
    }
}
