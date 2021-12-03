using Dominio.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Pais
{
    public class Editar
    {
        public class Ejecuta : IRequest
        {
            public Guid IdPais { get; set; }
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
                var pais = await _context.TblCatPais.FindAsync(request.IdPais);
                if (pais == null)
                {
                    throw new Exception("El país no está en el sistema");
                }

                pais.Descripcion = request.Descripcion ?? pais.Descripcion;
                pais.Estado = 2;

                var resultado = await _context.SaveChangesAsync();
                if (resultado > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("Error al modificar el país");
            }

        }
    }
}
