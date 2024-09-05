using Microsoft.AspNetCore.Mvc;
using Seminar;

using System.Linq;

namespace WebApplication4.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BenutzerverwaltungController : ControllerBase
    {
        private readonly BenutzerContext _context;

        public BenutzerverwaltungController(BenutzerContext context)
        {
            _context = context;
        }

        // GET /Benutzerverwaltung
        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var users = _context.Benutzerx.ToList();
            return Ok(users);
        }

        // GET /Benutzerverwaltung/{id}
        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            var user = _context.Benutzerx.Find(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        // POST /Benutzerverwaltung
        [HttpPost]
        public IActionResult CreateUser([FromBody] Benutzer user)
        {
            _context.Benutzerx.Add(user);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
        }

        // PUT /Benutzerverwaltung/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, [FromBody] Benutzer updatedUser)
        {
            var user = _context.Benutzerx.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            user.Vorname = updatedUser.Vorname;
            user.Email = updatedUser.Email;

            _context.Benutzerx.Update(user);
            _context.SaveChanges();
            return NoContent();
        }

        // DELETE /Benutzerverwaltung/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var user = _context.Benutzerx.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Benutzerx.Remove(user);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
