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

        // READ (GET ALL)
        [HttpGet]
        public IActionResult GetServices()
        {
            return Ok(_context.Services.ToList());
        }

        // CREATE
        [HttpPost]
        public IActionResult CreateService(Service service)
        {
            _context.Services.Add(service);
            _context.SaveChanges();
            return Ok(service);
        }

        // UPDATE
        [HttpPut("{id}")]
        public IActionResult UpdateService(int id, Service updatedService)
        {
            var service = _context.Services.Find(id);
            if (service == null)
            {
                return NotFound();
            }

            service.Name = updatedService.Name;
            service.Price = updatedService.Price;

            _context.SaveChanges();
            return Ok(service);
        }

        // DELETE
        [HttpDelete("{id}")]
        public IActionResult DeleteService(int id)
        {
            var service = _context.Services.Find(id);
            if (service == null)
            {
                return NotFound();
            }

            _context.Services.Remove(service);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
