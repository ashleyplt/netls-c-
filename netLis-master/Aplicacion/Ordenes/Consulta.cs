using AutoMapper;
using Dominio.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Ordenes
{
    public class Consulta
    {
        public class Ejecuta : IRequest<List<TblOrdenes>> { }

        public class Manejador : IRequestHandler<Ejecuta, List<TblOrdenes>>
        {
            private readonly netLisContext _context;
            private readonly IMapper _mapper;
            public Manejador(netLisContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<List<TblOrdenes>> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var ordenes = await _context.TblOrdenes
                    .ToListAsync();
                return ordenes;
            }
        }
    }
}
