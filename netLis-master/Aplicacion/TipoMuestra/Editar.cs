using Dominio.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.TipoMuestra
{
    public class Editar
    {
        public class Ejecuta : IRequest
        {
            public Guid IdTipoMuestra { get; set; }
            public string Descripcion { get; set; }
            public int Estado { get; set; }
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
                var tipo_muestra = await _context.TblCatTipoMuestras.FindAsync(request.IdTipoMuestra);
                if (tipo_muestra == null)
                {
                    throw new Exception("El tipo de muestra no está en el sistema" );
                }

                tipo_muestra.Descripcion = request.Descripcion ?? tipo_muestra.Descripcion;

                var resultado = await _context.SaveChangesAsync();
                if (resultado > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("Error al modificar el tipo de muestra");
            }

        }
    }   
}
