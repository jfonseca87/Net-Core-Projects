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
    public class ListadoController : ControllerBase
    {
        private readonly ITiposDocumentoService tiposDocumento;

        public ListadoController(ITiposDocumentoService tiposDocumento)
        {
            this.tiposDocumento = tiposDocumento;
        }

        [HttpGet]
        public IActionGeneralMessage GetTiposDocumento()
        {
            return ActionExecutioner.ActionExecution(() =>  
            {
                return tiposDocumento.GetTiposDocumento();
            });
        }
    }
}
