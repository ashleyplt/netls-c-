using Aplicacion.Resultados;
using Dominio.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResultadoController : MiControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<List<TblResultado>>> Get()
        {
            return await Mediator.Send(new Consulta.Ejecuta());
        }
    }
}
