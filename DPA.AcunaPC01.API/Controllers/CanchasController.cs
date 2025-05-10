using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DPA.AcunaPC01.DOMAIN.Core.Entities;
using DPA.AcunaPC01.DOMAIN.Infraestructure.Data;

namespace DPA.AcunaPC01.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CanchasController : ControllerBase
    {
        private readonly SistemaReservasCanchasContext _context;

        public CanchasController(SistemaReservasCanchasContext context)
        {
            _context = context;
        }

        // GET: api/Canchas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Canchas>>> GetCanchas()
        {
            return await _context.Canchas.ToListAsync();
        }

        // GET: api/Canchas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Canchas>> GetCanchas(int id)
        {
            var canchas = await _context.Canchas.FindAsync(id);

            if (canchas == null)
            {
                return NotFound();
            }

            return canchas;
        }

        // PUT: api/Canchas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCanchas(int id, Canchas canchas)
        {
            if (id != canchas.Id)
            {
                return BadRequest();
            }

            _context.Entry(canchas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CanchasExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Canchas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Canchas>> PostCanchas(Canchas canchas)
        {
            _context.Canchas.Add(canchas);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCanchas", new { id = canchas.Id }, canchas);
        }

        // DELETE: api/Canchas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCanchas(int id)
        {
            var canchas = await _context.Canchas.FindAsync(id);
            if (canchas == null)
            {
                return NotFound();
            }

            _context.Canchas.Remove(canchas);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CanchasExists(int id)
        {
            return _context.Canchas.Any(e => e.Id == id);
        }
    }
}
