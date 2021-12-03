using Dominio.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.TipoMuestra
{
    public class Consulta
    {
        public class Ejecuta : IRequest<List<TblCatTipoMuestra>> { }

        public class Manejador : IRequestHandler<Ejecuta, List<TblCatTipoMuestra>>
        {
            private readonly netLisContext _context;
            public Manejador(netLisContext context)
            {
                _context = context;
            }
            public async Task<List<TblCatTipoMuestra>> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var tipo_muestra = await _context.TblCatTipoMuestras.ToListAsync();
                return tipo_muestra;
            }
        }
    }
}
