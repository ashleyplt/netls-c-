using Dominio.Model;
using MediatR;
using Persistencia;
using System;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.TipoOrden
{
    public class Eliminar
    {
        public class Ejecuta : IRequest
        {
            public Guid Id { get; set; }
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
                var tipo_orden = await _context.TblCatTipoOrdens.FindAsync(request.Id);
                if (tipo_orden == null)
                {

                    throw new Exception("El tipo de orden no existe");
                }
                _context.Remove(tipo_orden);

                var resultado = await _context.SaveChangesAsync();
                if (resultado > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("Error al eliminar el tipo de orden");
            }
        }
    }
}
