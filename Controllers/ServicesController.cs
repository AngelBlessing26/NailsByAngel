using Microsoft.AspNetCore.Mvc;
using NailssByAngel.Data;
using NailssByAngel.Models;

namespace NailssByAngel.Controllers
{
    [ApiController]
    [Route("api/services")]
    public class ServicesController : ControllerBase
    {
        private readonly ApiContext _context;

        public ServicesController(ApiContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult CreateService(Service service)
        {
            _context.Services.Add(service);
            _context.SaveChanges();
            return Ok(service);
        }

        [HttpGet]
        public IActionResult GetServices()
        {
            return Ok(_context.Services);
        }
    }
}