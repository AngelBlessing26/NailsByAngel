using Microsoft.AspNetCore.Mvc;
using NailssByAngel.Data;
using NailssByAngel.Models;
using NailssByAngel.DTOs;


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

        // READ ALL
        [HttpGet]
        public IActionResult GetClients()
        {
           var clients = _context.Clients
             .Select(c => new ClientDto
             {
                 Id = c.Id,
                 Name = c.Name,
                 Email = c.Email
             })
             .ToList();

            return Ok(clients);


            return Ok(clients);
        }

        // READ ONE
        [HttpGet("{id}")]
        public IActionResult GetClient(int id)
        {
            var client = _context.Clients.Find(id);
            if (client == null) return NotFound();

            return Ok(new ClientDto
            {
                Id = client.Id,
                Name = client.Name,
                Email = client.Email
            });
        }

        // CREATE
        [HttpPost]
        public IActionResult CreateClient(CreateClientDto dto)
        {
            var client = new Client
            {
                Name = dto.Name,
                Email = dto.Email
            };

            _context.Clients.Add(client);
            _context.SaveChanges();

            return Ok(client);
        }

        // UPDATE
        [HttpPut("{id}")]
        public IActionResult UpdateClient(int id, CreateClientDto dto)
        {
            var client = _context.Clients.Find(id);
            if (client == null) return NotFound();

            client.Name = dto.Name;
            client.Email = dto.Email;

            _context.SaveChanges();
            return NoContent();
        }

        // DELETE
        [HttpDelete("{id}")]
        public IActionResult DeleteClient(int id)
        {
            var client = _context.Clients.Find(id);
            if (client == null) return NotFound();

            _context.Clients.Remove(client);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
