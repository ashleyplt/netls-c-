using Aplicacion.TipoServicio;
using Dominio.Model;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoServicioController : MiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<TblCatTipoServicio>>> Get()
        {
            return await Mediator.Send(new Consulta.Ejecuta());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TblCatTipoServicio>> Detalle(Guid id)
        {
            return await Mediator.Send(new ConsultaId.TipoServicioUnico { Id = id });
        }
    }
}
