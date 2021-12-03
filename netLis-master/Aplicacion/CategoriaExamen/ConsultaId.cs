using Dominio.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.CategoriaExamen
{
    public class ConsultaId
    {
        public class CategoriaExamenUnico : IRequest<TblCatCategoriaExamenes>
        {
            public Guid Id { get; set; }
        }

        public class Manejador : IRequestHandler<CategoriaExamenUnico, TblCatCategoriaExamenes>
        {
            private readonly netLisContext _context;
            public Manejador(netLisContext context)
            {
                _context = context;
            }

            public async Task<TblCatCategoriaExamenes> Handle(CategoriaExamenUnico request, CancellationToken cancellationToken)
            {
                var categoria_exam = await _context.TblCatCategoriaExamenes.FindAsync(request.Id);
                return categoria_exam;
            }

        }
    }
}
