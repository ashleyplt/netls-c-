using Dominio;
using Dominio.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Paciente
{
    public class Nuevo
    {
        public class Ejecuta : IRequest
        {
            public string Nacionalidad { get; set; }
            public string Identificacion { get; set; }
            public string NumIdentificacion { get; set; }
            public string NumInss { get; set; }
            public string EstadoCivil { get; set; }
            public string Email { get; set; }
            public string Sexo { get; set; }
            public string Pais { get; set; }
            public string Departamento { get; set; }
            public string TipoSangre { get; set; }
            public string Profesiones { get; set; }
            public string PrimerNombre { get; set; }
            public string SegundoNombre { get; set; }
            public string PrimerApellido { get; set; }
            public string SegundoApellido { get; set; }
            public DateTime FechaNac { get; set; }
            public string DireccionDomiciliar { get; set; }
            public string TelefonoDomiciliar { get; set; }
            public string TelefonoMovil { get; set; }
            public string Religion { get; set; }
            public string Activo { get; set; }
            public string Embarazada { get; set; }
            public string Fallecido { get; set; }
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
                var departamentoId = Guid.NewGuid();
                var sucursalId = Guid.NewGuid();
                var tipoSangreId = Guid.NewGuid();
                var identificacionId = Guid.NewGuid();
                var nacionalidadId = Guid.NewGuid();
                var estadoCivilId = Guid.NewGuid();
                var sexoId = Guid.NewGuid();
                var paisId = Guid.NewGuid();
                var profesionId = Guid.NewGuid();
                var religionId = Guid.NewGuid();

                var rnacionalidad = new TblCatNacionalidad
                {
                    IdNacionalidad = nacionalidadId,
                    Descripcion = request.Nacionalidad
                };
                _context.TblCatNacionalidads.Add(rnacionalidad);

                var ridentificacion = new TblCatIdentificacion
                {
                    IdIdentificacion = identificacionId,
                    IdNacionalidad = nacionalidadId,
                    Descripcion = request.Nacionalidad,
                    Estado = 1
                };
                _context.TblCatIdentificacions.Add(ridentificacion);

                var rpais = new TblCatPais
                {
                    IdPais = paisId,
                    Descripcion = request.Pais,
                    Estado = 1
                };
                _context.TblCatPais.Add(rpais);

                var rdepartamento = new TblCatDepartamento
                {
                    IdDepartamento = departamentoId,
                    IdPais = paisId,
                    Descripcion = request.Departamento,
                    Estado = 1
                };
                _context.TblCatDepartamentos.Add(rdepartamento);

                var restado = new TblCatEstadoCivil
                {
                    IdEstadoCivil = estadoCivilId,
                    Descripcion = request.Nacionalidad,
                    Estado = 1
                };
                _context.TblCatEstadoCivils.Add(restado);

                var rsexo = new TblCatSexo
                {
                    IdSexo = sexoId,
                    Descripcion = request.Sexo
                };
                _context.TblCatSexos.Add(rsexo);

                var rsangre = new TblCatTipoSangre
                {
                    IdTipoSangre = tipoSangreId,
                    Descripcion = request.TipoSangre
                };
                _context.TblCatTipoSangre.Add(rsangre);

                var rprofesion = new TblCatProfesiones
                {
                    IdProfesiones = profesionId,
                    Descripcion = request.Profesiones,
                    Estado = 1
                };
                _context.TblCatProfesiones.Add(rprofesion);

                var rreligion = new TblCatReligion
                {
                    IdReigion = religionId,
                    Descripcion = request.Religion
                };
                _context.TblCatReligion.Add(rreligion);

                var rpaciente = new TblPaciente
                {
                    IdIdentificacion = identificacionId,
                    NumIdentificacion = request.NumIdentificacion,
                    NumInss = request.NumInss,
                    IdEstadoCivil = estadoCivilId,
                    Email = request.Email,
                    IdSexo = sexoId,
                    IdPaisNac = paisId,
                    IdDepartamentoNac = departamentoId,
                    IdPaisRes = paisId,
                    IdDepartamentoRes = departamentoId,
                    IdTipoSangre = tipoSangreId,
                    IdProfesiones = profesionId,
                    PrimerNombre = request.PrimerNombre,
                    SegundoNombre = request.SegundoNombre,
                    PrimerApellido = request.PrimerApellido,
                    SegundoApellido = request.SegundoApellido,
                    FechaNac = request.FechaNac,
                    DireccionDomiciliar = request.DireccionDomiciliar,
                    TelefonoDomiciliar = request.TelefonoDomiciliar,
                    TelefonoMovil = request.TelefonoMovil,
                    Religion = religionId,
                    Activo = request.Activo,
                    Emabrazada = request.Embarazada,
                    Fallecido = request.Fallecido,
                    Estado = 1
                };
                _context.TblPacientes.Add(rpaciente);

                var valor = await _context.SaveChangesAsync();
                if (valor > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("No se pudo guardar el tipo de orden.");
            }
        }
    }
}
