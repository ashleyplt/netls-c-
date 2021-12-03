using Dominio.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.TipoSangre
{
    public class Editar
    {
        public class Ejecuta : IRequest
        {
            public Guid IdTipoSangre { get; set; }
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
                var tipo_sangre = await _context.TblCatTipoSangre.FindAsync(request.IdTipoSangre);
                if (tipo_sangre == null)
                {
                    throw new Exception("El tipo de sangre no está en el sistema");
                }

                tipo_sangre.Descripcion = request.Descripcion ?? tipo_sangre.Descripcion;

                var resultado = await _context.SaveChangesAsync();
                if (resultado > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("Error al modificar el tipo de sangre");
            }

        }
    }
}
