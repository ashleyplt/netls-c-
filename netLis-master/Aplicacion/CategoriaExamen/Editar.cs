using Dominio.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.CategoriaExamen
{
    public class Editar
    {
        public class Ejecuta : IRequest
        {
            public Guid IdCategoriaExamen { get; set; }
            public string Descripcion { get; set; }
            public int Estado { get; set; }
        }
        public class Manejador : IRequestHandler<Ejecuta>
        {
            private readonly netLisContext _context;
            public Manejador(netLisContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var cat_examen = await _context.TblCatCategoriaExamenes.FindAsync(request.IdCategoriaExamen);
                if (cat_examen == null)
                {
                    throw new Exception("La categoría de examen no está en el sistema");
                }

                cat_examen.Descripcion = request.Descripcion ?? cat_examen.Descripcion;

                var resultado = await _context.SaveChangesAsync();
                if (resultado > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("Error al modificar la categoria de examen");
            }

        }
    }
}
