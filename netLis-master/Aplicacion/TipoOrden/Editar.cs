using Dominio.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.TipoOrden
{
    public class Editar
    {
        public class Ejecuta : IRequest
        {
            public Guid IdTipoOrden { get; set; }
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
                var tipo_orden = await _context.TblCatTipoOrdens.FindAsync(request.IdTipoOrden);
                if (tipo_orden == null)
                {
                    throw new Exception("El tipo de orden no está en el sistema");
                }

                tipo_orden.Descripcion = request.Descripcion ?? tipo_orden.Descripcion;

                var resultado = await _context.SaveChangesAsync();
                if (resultado > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("Error al modificar el tipo de orden");
            }
        }
    }
}
