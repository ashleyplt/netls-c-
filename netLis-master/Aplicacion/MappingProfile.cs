using Aplicacion.Ordenes;
using AutoMapper;
using Dominio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TblOrdenes, OrdenesDto>()
                .ForMember(x => x.TipoServicio, y => y.MapFrom(z => z.IdTipoServicioNavigation.Descripcion))
                .ForMember(x => x.OrdenesDetallesLink, y => y.MapFrom(z => z.TblOrdenesDetalles.Select(a => a.IdExamenNavigation).ToList()));
            CreateMap<TblOrdenesDetalle, OrdenesDetalleDto>();
            CreateMap<TblExamenes, ExamenDto>();
            CreateMap<TblCatTipoServicio, OrdenesDto>()
                .ForMember(x => x.TipoServicio, y => y.MapFrom(z => z.Descripcion));
        }
    }
}
