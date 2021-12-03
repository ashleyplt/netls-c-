using Dominio.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Perfiles
{
    public class ConsultaId
    {
        public class PerfilUnico : IRequest<TblCatPerfiles>
        {
            public Guid Id { get; set; }
        }

        public class Manejador : IRequestHandler<PerfilUnico, TblCatPerfiles>
        {
            private readonly netLisContext _context;
            public Manejador(netLisContext context)
            {
                _context = context;
            }

            public async Task<TblCatPerfiles> Handle(PerfilUnico request, CancellationToken cancellationToken)
            {
                var perfil = await _context.TblCatPerfiles.FindAsync(request.Id);
                return perfil;
            }

        }
    }
}
