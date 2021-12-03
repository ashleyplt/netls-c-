using Dominio.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.UnidadMedida
{
    public class ConsultaId
    {
        public class UnidadMedidaUnico : IRequest<TblCatUnidadMedida>
        {
            public Guid Id { get; set; }
        }

        public class Manejador : IRequestHandler<UnidadMedidaUnico, TblCatUnidadMedida>
        {
            private readonly netLisContext _context;
            public Manejador(netLisContext context)
            {
                _context = context;
            }

            public async Task<TblCatUnidadMedida> Handle(UnidadMedidaUnico request, CancellationToken cancellationToken)
            {
                var unidad_medida = await _context.TblCatUnidadMedidas.FindAsync(request.Id);
                return unidad_medida;
            }

        }
    }
}
