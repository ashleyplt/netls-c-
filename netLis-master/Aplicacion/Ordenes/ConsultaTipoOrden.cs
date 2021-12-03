using Dominio.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Ordenes
{
    public class ConsultaTipoOrden
    {
        public class ConsultaTipoUnico : IRequest<List<TblOrdenes>>
        {
            public Guid Tipo { get; set; }
        }

        public class Manejador : IRequestHandler<ConsultaTipoUnico, List<TblOrdenes>>
        {
            private readonly netLisContext _context;
            public Manejador(netLisContext context)
            {
                _context = context;
            }

            public async Task<List<TblOrdenes>> Handle(ConsultaTipoUnico request, CancellationToken cancellationToken)
            {
                var ordenes = await _context.TblOrdenes.Where(x => x.IdTipoOrden == request.Tipo).ToListAsync();
                return ordenes;
            }

        }
    }
}
