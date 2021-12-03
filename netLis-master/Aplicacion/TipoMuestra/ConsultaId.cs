using Dominio.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.TipoMuestra
{
    public class ConsultaId
    {
        public class TipoMuestraUnico : IRequest<TblCatTipoMuestra>
        {
            public Guid Id { get; set; }
        }

        public class Manejador : IRequestHandler<TipoMuestraUnico, TblCatTipoMuestra>
        {
            private readonly netLisContext _context;
            public Manejador(netLisContext context)
            {
                _context = context;
            }

            public async Task<TblCatTipoMuestra> Handle(TipoMuestraUnico request, CancellationToken cancellationToken)
            {
                var tipo_muestra = await _context.TblCatTipoMuestras.FindAsync(request.Id);
                return tipo_muestra;
            }
            
        }
    }
}
