using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using API_Console_Jeux.Data;
using System;
using System.Linq;

namespace API_Console_Jeux.Models
{
    public class VentesData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new API_Console_JeuxContext(
            serviceProvider.GetRequiredService<
            DbContextOptions<API_Console_JeuxContext>>()))
            {
                context.Database.EnsureCreated();
                // S’il y a déjà des ventes dans la base
                if (context.Ventes.Any())
                {
                    return; // On ne fait rien
                }
                // Sinon on en ajoute un
                context.Ventes.AddRange(
                new Ventes
                {
                    Nombre_ventes = 3,
                    Annee = "2003"
                }
                );
                context.SaveChanges();
            }
        }
    }
}
