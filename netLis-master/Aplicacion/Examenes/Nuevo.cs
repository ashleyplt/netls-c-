using Dominio.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Examenes
{
    public class Nuevo
    {
        public class Ejecuta : IRequest
        {
            public string AreaLabServicio { get; set; }
            public string CategoriaExamenes { get; set; }
            public string TipoMuestra { get; set; }
            public string UnidadMedidas { get; set; }
            public string TipoResultado { get; set; }
            public string Descripcion { get; set; }
            public string DescripcionCorta { get; set; }
            public string Confidencial { get; set; }
            public int Estado { get; set; }

            public List<string> Indicacion { get; set; }
            public List<string> Perfil { get; set; }
            public List<ValoresNormales> ValoresNormales { get; set; }

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
                Guid examenId = Guid.NewGuid();
                Guid medidaId = Guid.NewGuid();
                Guid tipoResultadoId = Guid.NewGuid();
                Guid tipoMuestraId = Guid.NewGuid();
                Guid catExamenId = Guid.NewGuid();
                Guid labServId = Guid.NewGuid();

                var unidad_medida = new TblCatUnidadMedida
                {
                    IdUnidadMedidas = medidaId,
                    UnidadMedida = request.UnidadMedidas,
                    Estado = 1
                };
                _context.TblCatUnidadMedidas.Add(unidad_medida);

                var tipo_resultado = new TblCatTipoResultado
                {
                    IdTipoResultado = tipoResultadoId,
                    Descripcion = request.TipoResultado
                };
                _context.TblCatTipoResultados.Add(tipo_resultado);

                var tipo_muestra = new TblCatTipoMuestra
                {
                    IdTipoMuestra = tipoMuestraId,
                    Descripcion = request.TipoMuestra,
                    Estado = 1
                };
                _context.TblCatTipoMuestras.Add(tipo_muestra);

                var cat_examen = new TblCatCategoriaExamenes
                {
                    IdCategoriaExamenes = catExamenId,
                    Descripcion = request.CategoriaExamenes,
                    Estado = 1
                };
                _context.TblCatCategoriaExamenes.Add(cat_examen);

                var arealab_serv = new TblCatAreasLabServicio
                {
                    IdAreaLabServicio = labServId,
                    Descripcion = request.AreaLabServicio

                };
                _context.TblCatAreasLabServicios.Add(arealab_serv);

                var examen = new TblExamenes
                {
                    IdExamen = examenId,
                    IdAreaLabServicio = labServId,
                    IdCategoriaExamenes = catExamenId,
                    IdTipoMuestra = tipoMuestraId,
                    IdUnidadMedidas = medidaId,
                    IdTipoResultado = tipoResultadoId,
                    Descripcion = request.Descripcion,
                    DescripcionCorta = request.DescripcionCorta,
                    Confidencial = request.Confidencial,
                    Estado = 1
                };
                _context.TblExamenes.Add(examen);

                if (request.ValoresNormales != null)
                {
                    foreach (var valorNormal in request.ValoresNormales)
                    {
                        var sexoId = Guid.NewGuid();
                        var sexo = new TblCatSexo
                        {
                            IdSexo = sexoId,
                            Descripcion = valorNormal.Sexo
                        };
                        _context.TblCatSexos.Add(sexo);

                        var valores = new TblCatValoresNormales
                        {
                            IdValoresNormales = Guid.NewGuid(),
                            IdExamen = examenId,
                            IdSexo = sexoId,
                            RangoAlto = valorNormal.RangoAlto,
                            RangoBajo = valorNormal.RangoBajo,
                            Estado = 1
                        };
                        _context.TblCatValoresNormales.Add(valores);
                    }
                }

                if (request.Perfil != null)
                {
                    foreach (var descripcion in request.Perfil)
                    {
                        var pefilId = Guid.NewGuid();
                        var catPerfil = new TblCatPerfiles
                        {
                            IdPerfiles = pefilId,
                            Descripcion = descripcion,
                            Estado = 1
                        };
                        _context.TblCatPerfiles.Add(catPerfil);

                        var perfilExamen = new TblCatPerfilesExamenes
                        {
                            IdPerfilesExamenes = Guid.NewGuid(),
                            IdExamen = examenId,
                            IdPerfiles = pefilId
                        };
                        _context.TblCatPerfilesExamenes.Add(perfilExamen);
                    }
                }
                var valor = await _context.SaveChangesAsync();
                if (valor > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("No se pudo guardar el examen.");
            }
        }
    }
}
