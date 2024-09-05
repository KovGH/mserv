using Microsoft.AspNetCore.Mvc;
using Seminar;

namespace WebApplication4.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProduktverwaltungController : ControllerBase
    {
        private readonly ProduktContext _context;

        public ProduktverwaltungController(ProduktContext context)
        {
            _context = context;
        }

        // GET /Produktverwaltung
        [HttpGet]
        public IActionResult GetAllProdukte()
        {
            var produkte = _context.Produkte.ToList();
            return Ok(produkte);
        }

        // GET /Produktverwaltung/{id}
        [HttpGet("{id}")]
        public IActionResult GetProduktById(int id)
        {
            var produkt = _context.Produkte.Find(id);
            if (produkt == null)
            {
                return NotFound();
            }
            return Ok(produkt);
        }

        // POST /Produktverwaltung
        [HttpPost]
        public IActionResult CreateProdukt([FromBody] Produkt produkt)
        {
            _context.Produkte.Add(produkt);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetProduktById), new { id = produkt.ProduktId }, produkt);
        }

        // PUT /Produktverwaltung/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateProdukt(int id, [FromBody] Produkt updatedProdukt)
        {
            var produkt = _context.Produkte.Find(id);
            if (produkt == null)
            {
                return NotFound();
            }

            produkt.Name = updatedProdukt.Name;
            produkt.Beschreibung = updatedProdukt.Beschreibung;
            produkt.Preis = updatedProdukt.Preis;
            produkt.Kategorie = updatedProdukt.Kategorie;
            produkt.Hersteller = updatedProdukt.Hersteller;
            produkt.Lagerbestand = updatedProdukt.Lagerbestand;
            produkt.Lieferzeit = updatedProdukt.Lieferzeit;
            produkt.Gewicht = updatedProdukt.Gewicht;
            produkt.EAN = updatedProdukt.EAN;

            _context.Produkte.Update(produkt);
            _context.SaveChanges();
            return NoContent();
        }

        // DELETE /Produktverwaltung/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteProdukt(int id)
        {
            var produkt = _context.Produkte.Find(id);
            if (produkt == null)
            {
                return NotFound();
            }

            _context.Produkte.Remove(produkt);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
