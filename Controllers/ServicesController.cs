using Microsoft.AspNetCore.Mvc;
using NailssByAngel.Data;
using NailssByAngel.Models;
using System.Data.Entity;

namespace NailssByAngel.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServicesController : ControllerBase
    {
        private readonly ApiContext _context;

        public ServicesController(ApiContext context)
        {
            _context = context;
        }

        // GET: api/services
        [HttpGet]
        public async Task<IActionResult> GetServices()
        {
            return Ok(await _context.Services.ToListAsync());
        }

        // POST: api/services
        [HttpPost]
        public async Task<IActionResult> CreateService(Service service)
        {
            _context.Services.Add(service);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetServices), new { id = service.Id }, service);
        }
    }
}