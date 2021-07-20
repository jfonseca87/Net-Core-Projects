using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestCore.Models;

namespace TestCore.Controllers
{
    [ApiController]
    [Route("api/Listado")]
    // [RequestFilter]
    public class ListadoController : ControllerBase
    {
        private readonly ITiposDocumentoService tiposDocumento;

        public ListadoController(ITiposDocumentoService tiposDocumento)
        {
            this.tiposDocumento = tiposDocumento;
        }

        [HttpGet]
        public IActionResult GetTiposDocumento()
        {
            try
            {
                return Ok(tiposDocumento.GetTiposDocumento());
                //return ActionExecutioner.ActionExecution(() =>  
                //{
                //    return tiposDocumento.GetTiposDocumento();
                //});
            }
            catch (Exception ex)
            {
                var asd = ex.GetType().Name;
                return Ok();
            }
        }
    }
}
