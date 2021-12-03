using Dominio.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Resultados
{
    public class Nuevo
    {
        public class Ejecuta : IRequest
        {
            public Guid IdExamen { get; set; }
            public Guid IdOrden { get; set; }
            public string Resultado { get; set; }
            public string Observacion { get; set; }
            public string Procesado { get; set; }
            public int Estado { get; set; }
        }

        public class Manejador : IRequest<Ejecuta>
        {
            private readonly netLisContext _context;
            public Manejador(netLisContext context)
            {
                _context = context;
            }
            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                Guid idresultado = Guid.NewGuid();
                var resultado = new TblResultado
                {
                    IdResultados = idresultado,
                    IdExamen = request.IdExamen,
                    IdOrden = request.IdOrden,
                    Resultado = request.Resultado,
                    Observaciones = request.Observacion,
                    Procesado = request.Procesado,
                    Estado = 1
                };
                _context.TblResultados.Add(resultado);
                var valor = await _context.SaveChangesAsync();
                if(valor > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("No se puede guardar el resultado");
            }
        }
    }
}
