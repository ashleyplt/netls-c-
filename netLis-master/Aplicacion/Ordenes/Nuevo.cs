using Dominio.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Ordenes
{
    public class Nuevo
    {
        public class Ejecuta : IRequest
        {
            public string NOrden { get; set; }
            public Guid IdtblMedico { get; set; }
            public Guid IdPaciente { get; set; }
            public string TipoServicio { get; set; }
            public Guid TipoOrden { get; set; }
            public string Asistencia { get; set; }
            public string Observaciones { get; set; }
            public string Activo { get; set; }
            //public DateTime? FechaImprime { get; set; }
            //public string UsuarioImprime { get; set; }
            public string Finalizado { get; set; }
            public DateTime? FechaCita { get; set; }
            public DateTime FechaPreporte { get; set; }
            public List<OrdenDetalle> Detalle { get; set; }
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
                Guid ordenId = Guid.NewGuid();
                Guid tipoServicioId = Guid.NewGuid();

                var rtipoServicio = new TblCatTipoServicio
                {
                    IdTipoServicio = ordenId,
                    Descripcion = request.TipoServicio
                };
                _context.TblCatTipoServicios.Add(rtipoServicio);

                var ordenes = new TblOrdenes
                {
                    IdOrden = ordenId,
                    NOrden = request.NOrden,
                    IdtblMedico = request.IdtblMedico,
                    IdPaciente = request.IdPaciente,
                    IdTipoServicio = tipoServicioId,
                    IdTipoOrden = request.TipoOrden,
                    Asistencia = request.Asistencia,
                    Observaciones = request.Observaciones,
                    FechaOrden = DateTime.Now,
                    Activo = request.Activo,
                    Estado = 1,
                    Finalizado = request.Finalizado,
                    FechaCita = request.FechaCita,
                    FechaPreporte = request.FechaPreporte
                };
                _context.TblOrdenes.Add(ordenes);

                if (request.Detalle != null)
                {
                    foreach (var od in request.Detalle)
                    {
                        var detalle = new TblOrdenesDetalle
                        {
                            IdOrdenDetalle = Guid.NewGuid(),
                            IdOrden = ordenId,
                            NOrden = request.NOrden,
                            IdExamen = od.IdExamen,
                            Activo = od.Activo
                        };
                        _context.TblOrdenesDetalles.Add(detalle);
                    }
                }
                var valor = await _context.SaveChangesAsync();
                if (valor > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("No se pudo guardar la orden.");
            }
        }
    }
}
