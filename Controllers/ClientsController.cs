using Microsoft.AspNetCore.Mvc;
using NailssByAngel.Controllers;
using NailssByAngel.Data;

namespace NailssByAngel.Controllers
{
    [ApiController]
    [Route("api/clients")]
    public class ClientsCocntroller(ApiContext context) : ControllerBase
    {
        private readonly ApiContext context = context;

        [HttpGet]
        public IActionResult GetClients()
        {
            return Ok(context.Clients);
        }
    }
}