using Microsoft.AspNetCore.Mvc;
using NailssByAngel.Data;

namespace NailssByAngel.Controllers
{
    [ApiController]
    [Route("api/clients")]
    public class ClientsController : ControllerBase
    {
        private readonly ApiContext _context;

        public ClientsController(ApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetClients()
        {
            return Ok(_context.Clients);
        }
    }
}