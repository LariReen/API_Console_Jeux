using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using API_Console_Jeux.Data;
using System;
using System.Linq;

namespace API_Console_Jeux.Models
{
    public class ConstructeurData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new API_Console_JeuxContext(
            serviceProvider.GetRequiredService<
            DbContextOptions<API_Console_JeuxContext>>()))
            {
                context.Database.EnsureCreated();
                // S’il y a déjà des constructeurs dans la base
                if (context.Constructeur.Any())
                {
                    return; // On ne fait rien
                }
                // Sinon on en ajoute un
                context.Constructeur.AddRange(
                new Constructeur
                {
                    Nom_constructeur = "Vanderhouson",
                    List_console = new List<JeuxConsole>
                    { 
                        new JeuxConsole
                        {
                            Nom_jeuxconsole = "Nintendo",
                            Type_jeuxconsole = "Manette",
                            List_ventes = new List<Ventes>
                            {
                                new Ventes
                                {
                                    Nombre_ventes = 7,
                                    Annee = "2024"
                                }
                            
                            }

                        }
                        
                    }
                }
                );
                context.SaveChanges();
            }
        }
    }
}
