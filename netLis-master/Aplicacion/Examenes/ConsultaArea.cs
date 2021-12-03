using Dominio.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Examenes
{
    public class ConsultaArea
    {
        public class ConsultaAreaUnico : IRequest<List<TblExamenes>>
        {
            public Guid Area { get; set; }
        }

        public class Manejador : IRequestHandler<ConsultaAreaUnico, List<TblExamenes>>
        {
            private readonly netLisContext _context;
            public Manejador(netLisContext context)
            {
                _context = context;
            }

            public async Task<List<TblExamenes>> Handle(ConsultaAreaUnico request, CancellationToken cancellationToken)
            {
                var examenes = await _context.TblExamenes.Where(x => x.IdAreaLabServicio == request.Area).ToListAsync();
                return examenes;
            }

        }
    }
}
