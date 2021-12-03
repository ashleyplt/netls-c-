using Dominio.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.TipoResultados
{
    public class Editar
    {
        public class Ejecuta : IRequest
        {
            public Guid IdTiporResultado { get; set; }
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
                var tipo_resultado = await _context.TblCatTipoResultados.FindAsync(request.IdTiporResultado);
                if (tipo_resultado == null)
                {
                    throw new Exception("El tipo de resultado no está en el sistema");
                }

                tipo_resultado.Descripcion = request.Descripcion ?? tipo_resultado.Descripcion;

                var resultado = await _context.SaveChangesAsync();
                if (resultado > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("Error al modificar el tipo de resultado");
            }

        }
    }
}
