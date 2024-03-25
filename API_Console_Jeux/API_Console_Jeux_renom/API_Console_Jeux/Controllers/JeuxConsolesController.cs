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
        // GET: api/JeuxConsoles
        [HttpGet]
        public async Task


        // GET: api/JeuxConsoles/5
        [HttpGet("{id}")]
        public async Task
 
            if (jeuxConsole == null)
            {
                return NotFound();
    }
 
            return jeuxConsole;
        }


// PUT: api/JeuxConsoles/5
// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
[HttpPut("{id}")]
public async Task PutJeuxConsole(int id, JeuxConsole jeuxConsole)
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
public async Task
 
            return CreatedAtAction("GetJeuxConsole", new { id = jeuxConsole.Id }, jeuxConsole);
        }
 
        // DELETE: api/JeuxConsoles/5
        [HttpDelete("{id}")]
public async Task DeleteJeuxConsole(int id)
{
    // Cherchez le jeu console spécifié par l'ID, en incluant ses ventes associées
    var jeuxConsole = await _context.JeuxConsole
                                    .Include(j => j.List_ventes) // Chargez les ventes liées au jeu console
                                    .FirstOrDefaultAsync(j => j.Id == id);

    if (jeuxConsole == null)
    {
        return NotFound();
    }

    // Supprimez les ventes associées au jeu console
    _context.Ventes.RemoveRange(jeuxConsole.List_ventes);

    // Après la suppression des ventes, supprimez le jeu console lui-même
    _context.JeuxConsole.Remove(jeuxConsole);

    // Appliquez les suppressions dans la base de données
    await _context.SaveChangesAsync();

    return NoContent();
}


private bool JeuxConsoleExists(int id)
{
    return _context.JeuxConsole.Any(e => e.Id == id);
}
    }
}