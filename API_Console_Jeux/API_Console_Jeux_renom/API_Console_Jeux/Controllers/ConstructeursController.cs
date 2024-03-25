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
    public class ConstructeursController : ControllerBase
    {
        private readonly API_Console_JeuxContext _context;

        public ConstructeursController(API_Console_JeuxContext context)
        {
            _context = context;
        }

        // GET: api/Constructeurs
        [HttpGet]
        public async Task


        // GET: api/Constructeurs/5
        [HttpGet("{id}")]
        public async Task
 
            if (constructeur == null)
            {
                return NotFound();
    }
 
            return constructeur;
        }


// PUT: api/Constructeurs/5
// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
[HttpPut("{id}")]
public async Task PutConstructeur(int id, Constructeur constructeur)
{
    if (id != constructeur.Id)
    {
        return BadRequest();
    }

    _context.Entry(constructeur).State = EntityState.Modified;

    try
    {
        await _context.SaveChangesAsync();
    }
    catch (DbUpdateConcurrencyException)
    {
        if (!ConstructeurExists(id))
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

// POST: api/Constructeurs
// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
[HttpPost]
public async Task
 
            return CreatedAtAction("GetConstructeur", new { id = constructeur.Id }, constructeur);
        }
 
        // DELETE: api/Constructeurs/5
        [HttpDelete("{id}")]
public async Task DeleteConstructeur(int id)
{
    var constructeur = await _context.Constructeur
                                      .Include(c => c.List_console)
                                          .ThenInclude(jc => jc.List_ventes) // Chargez les ventes pour chaque jeu
                                      .FirstOrDefaultAsync(c => c.Id == id);

    if (constructeur == null)
    {
        return NotFound();
    }

    // Parcourez chaque JeuxConsole lié pour supprimer ses Ventes associées
    foreach (var jeuConsole in constructeur.List_console)
    {
        // Supprimez les Ventes liées à ce JeuxConsole
        _context.Ventes.RemoveRange(jeuConsole.List_ventes);
    }

    // Supprimez les JeuxConsole après avoir supprimé leurs Ventes
    _context.JeuxConsole.RemoveRange(constructeur.List_console);

    // Supprimez le Constructeur
    _context.Constructeur.Remove(constructeur);

    // Sauvegardez les changements dans la base de données
    await _context.SaveChangesAsync();

    return NoContent();
}


private bool ConstructeurExists(int id)
{
    return _context.Constructeur.Any(e => e.Id == id);
}
    }
}