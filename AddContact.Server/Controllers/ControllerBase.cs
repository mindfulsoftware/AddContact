using Microsoft.AspNetCore.Mvc;
using System;

namespace AddContact.Server.Controllers
{
    public abstract class ControllerBase : Controller
    {
        protected OkObjectResult CreateOkWithData(object data)
        {
            return Ok(new { data });
        }

        protected ActionResult CreateBadRequest(Exception ex, string friendlyMessage = null)
        {
            // TODO: logging, better error messages
            return BadRequest();
        }
    }
}
