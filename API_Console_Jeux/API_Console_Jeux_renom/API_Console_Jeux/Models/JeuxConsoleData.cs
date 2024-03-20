using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using API_Console_Jeux.Data;
using System;
using System.Linq;

namespace API_Console_Jeux.Models
{
    public class JeuxConsoleData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new API_Console_JeuxContext(
            serviceProvider.GetRequiredService<
            DbContextOptions<API_Console_JeuxContext>>()))
            {
                context.Database.EnsureCreated();
                // S’il y a déjà des jeux console dans la base
                if (context.JeuxConsole.Any())
                {
                    return; // On ne fait rien
                }
                // Sinon on en ajoute un
                context.JeuxConsole.AddRange(
                new JeuxConsole
                {
                    Nom_jeuxconsole = "PS5",
                    Type_jeuxconsole = "Console portable",
                    List_ventes = new List<Ventes> 
                    {
                       new Ventes 
                       {
                           Nombre_ventes = 3,
                           Annee = "2003"
                       }
                    }
                }
                );
                context.SaveChanges();
            }
        }
    }
}
