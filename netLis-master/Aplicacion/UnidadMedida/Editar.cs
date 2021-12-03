using Dominio.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.UnidadMedida
{
    public class Editar
    {
        public class Ejecuta : IRequest
        {
            public Guid IdUnidadMedida { get; set; }
            public string UnidadMedida { get; set; }
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
                var unidad_medida = await _context.TblCatUnidadMedidas.FindAsync(request.IdUnidadMedida);
                if (unidad_medida == null)
                {
                    throw new Exception("La unidad de medida no está en el sistema");
                }

                unidad_medida.UnidadMedida = request.UnidadMedida ?? unidad_medida.UnidadMedida;

                var resultado = await _context.SaveChangesAsync();
                if (resultado > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("Error al modificar la unidad de medida");
            }

        }
    }
}
