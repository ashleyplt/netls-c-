using Dominio.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Perfiles
{
    public class Editar
    {
        public class Ejecuta : IRequest
        {
            public Guid IdPerfiles { get; set; }
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
                var perfil = await _context.TblCatPerfiles.FindAsync(request.IdPerfiles);
                if (perfil == null)
                {
                    throw new Exception("El perfil no está en el sistema");
                }

                perfil.Descripcion = request.Descripcion ?? perfil.Descripcion;

                var resultado = await _context.SaveChangesAsync();
                if (resultado > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("Error al modificar el perfil");
            }

        }
    }
}
