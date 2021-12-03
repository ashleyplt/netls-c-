using Aplicacion.Ordenes;
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
    public class OrdenesController : MiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<TblOrdenes>>> Get()
        {
            return await Mediator.Send(new Consulta.Ejecuta());
        }

        [HttpGet("{tipo}")]
        public async Task<ActionResult<List<TblOrdenes>>> Detalle(Guid tipo)
        {
            return await Mediator.Send(new ConsultaTipoOrden.ConsultaTipoUnico { Tipo = tipo });
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Crear(Nuevo.Ejecuta data)
        {
            return await Mediator.Send(data);
        }
    }
}
