using Dominio.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.AreaLabServicio
{
    public class ConsultaId
    {
        public class AreaLabServUnico : IRequest<TblCatAreasLabServicio>
        {
            public Guid Id { get; set; }
        }

        public class Manejador : IRequestHandler<AreaLabServUnico, TblCatAreasLabServicio>
        {
            private readonly netLisContext _context;
            public Manejador(netLisContext context)
            {
                _context = context;
            }

            public async Task<TblCatAreasLabServicio> Handle(AreaLabServUnico request, CancellationToken cancellationToken)
            {
                var arealab_serv = await _context.TblCatAreasLabServicios.FindAsync(request.Id);
                return arealab_serv;
            }

        }
    }
}
