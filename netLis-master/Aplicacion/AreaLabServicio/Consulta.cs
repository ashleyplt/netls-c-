using Dominio.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace Aplicacion.AreaLabServicio
{
    public class Consulta
    {
        public class Ejecuta : IRequest<List<TblCatAreasLabServicio>> { }

        public class Manejador : IRequestHandler<Ejecuta, List<TblCatAreasLabServicio>>
        {
            private readonly netLisContext _context;
            public Manejador(netLisContext context)
            {
                _context = context;
            }
            public async Task<List<TblCatAreasLabServicio>> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var area_lab_servicio = await _context.TblCatAreasLabServicios.ToListAsync();
                return area_lab_servicio;
            }
        }
    }
}
