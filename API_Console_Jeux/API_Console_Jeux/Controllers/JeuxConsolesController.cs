using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_Console_Jeux.Data;
using API_Console_Jeux.Models;

namespace API_Console_Jeux.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JeuxConsolesController : ControllerBase
    {
        private readonly API_Console_JeuxContext _context;

        public JeuxConsolesController(API_Console_JeuxContext context)
        {
            _context = context;
        }

        // GET: api/JeuxConsoles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JeuxConsole>>> GetConsole()
        {
            return await _context.Console.ToListAsync();
        }

        // GET: api/JeuxConsoles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<JeuxConsole>> GetJeuxConsole(int id)
        {
            var jeuxConsole = await _context.Console.FindAsync(id);

            if (jeuxConsole == null)
            {
                return NotFound();
            }

            return jeuxConsole;
        }

        // PUT: api/JeuxConsoles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJeuxConsole(int id, JeuxConsole jeuxConsole)
        {
            if (id != jeuxConsole.Id)
            {
                return BadRequest();
            }

            _context.Entry(jeuxConsole).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JeuxConsoleExists(id))
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

        // POST: api/JeuxConsoles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<JeuxConsole>> PostJeuxConsole(JeuxConsole jeuxConsole)
        {
            _context.Console.Add(jeuxConsole);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetJeuxConsole", new { id = jeuxConsole.Id }, jeuxConsole);
        }

        // DELETE: api/JeuxConsoles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJeuxConsole(int id)
        {
            var jeuxConsole = await _context.Console.FindAsync(id);
            if (jeuxConsole == null)
            {
                return NotFound();
            }

            _context.Console.Remove(jeuxConsole);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool JeuxConsoleExists(int id)
        {
            return _context.Console.Any(e => e.Id == id);
        }
    }
}
