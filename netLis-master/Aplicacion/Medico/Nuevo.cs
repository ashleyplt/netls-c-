using Dominio.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Medico
{
    public class Nuevo
    {
        public class Ejecuta : IRequest
        {
            public string Nombres { get; set; }
            public string Apellidos { get; set; }

            //TblCatSucursales

            //Descripción en TblCatHospital: Estado
            public string Hospital { get; set; }
            //Descripción en País: Estado
            public string Pais { get; set; }
            //Descripción en TblCatDepartamento: IdPais y Estado
            public string Departamento { get; set; }
            //Descripción en TblCatSuscursales: IdHospital, IdDepartamento y IdPais
            public string Sucursal { get; set; }
            public string Direccion { get; set; }
            public string TelefonoSucursal { get; set; }

            /* Se ocuparán los mismos ID generados de los anteriores, ya que no es nuestra prioridad
            public Guid IdDepartamentoNac { get; set; }
            public Guid IdDepartamentoRes { get; set; }
            public Guid IdPaisNac { get; set; }
            public Guid IdPaisRes { get; set; }*/

            //TblCatIdentificacion
            //Descripción en TblCatIdentificacion: IdNacionalidad y Estado
            public string Identificacion { get; set; }
            //Descripción en TblCatNacionalidad
            public string Nacionalidad { get; set; }

            //TblCatEstadoCivil
            //Descripción en TblEstadoCivil: Estado
            public string EstadoCivil { get; set; }
            public string Sexo { get; set; }

            public string NumIdentificacion { get; set; }
            public string CodMinsa { get; set; }
            public DateTime FechaNac { get; set; }
            public string Email { get; set; }
            public string Telefono { get; set; }
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
                var paisId = Guid.NewGuid();
                var departamentoId = Guid.NewGuid();
                var sucursalId = Guid.NewGuid();
                var hospitalId = Guid.NewGuid();
                var identificacionId = Guid.NewGuid();
                var nacionalidadId = Guid.NewGuid();
                var estadoCivilId = Guid.NewGuid();

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

                var rhospital = new TblCatHospital
                {
                    IdHospital = hospitalId,
                    Descripcion = request.Hospital,
                    Estado = 1
                };
                _context.TblCatHospitals.Add(rhospital);

                var rsucursal = new TblCatSucursales
                {
                    IdSucursal = sucursalId,
                    IdHospital = hospitalId,
                    IdDepartamento = departamentoId,
                    IdPais = paisId,
                    Descripcion = request.Sucursal,
                    Direccion = request.Direccion,
                    Telefono = request.TelefonoSucursal,
                    UrlLogo = "",
                    Estado = 1
                };
                _context.TblCatSucursales.Add(rsucursal);

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

                var restado = new TblCatEstadoCivil
                {
                    IdEstadoCivil = estadoCivilId,
                    Descripcion = request.Nacionalidad,
                    Estado = 1
                };
                _context.TblCatEstadoCivils.Add(restado);

                var sexoId = Guid.NewGuid();
                var sexo = new TblCatSexo
                {
                    IdSexo = sexoId,
                    Descripcion = request.Sexo
                };
                _context.TblCatSexos.Add(sexo);

                var rmedico = new TblMedico
                {
                    IdTblMedico = Guid.NewGuid(),
                    Nombres = request.Nombres,
                    Apellidos = request.Apellidos,
                    IdtblCatSucursales = sucursalId,
                    FechaCreacion = DateTime.Now,
                    IdDepartamentoNac = departamentoId,
                    IdDepartamentoRes = departamentoId,
                    IdPaisNac = paisId,
                    IdPaisRes = paisId,
                    IdIdentificacion = identificacionId,
                    IdEstadoCivil = estadoCivilId,
                    IdSexo = sexoId,
                    NumIdentificacion = request.NumIdentificacion,
                    CodMinsa = request.CodMinsa,
                    FechaNac = request.FechaNac,
                    Email = request.Email,
                    Telefono = request.Telefono,
                    UrlFoto = "",
                    Estado = 1
                };
                _context.TblMedicos.Add(rmedico);
                var valor = await _context.SaveChangesAsync();
                if (valor > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("No se pudo guardar el médico.");
            }
        }
    }
}
