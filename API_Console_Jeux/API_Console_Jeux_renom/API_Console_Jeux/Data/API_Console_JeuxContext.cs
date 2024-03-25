using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using API_Console_Jeux.Models;

namespace API_Console_Jeux.Data
{
    public class API_Console_JeuxContext : DbContext
    {
        public API_Console_JeuxContext(DbContextOptions<API_Console_JeuxContext> options)
            : base(options)
        {
        }

        public DbSet<API_Console_Jeux.Models.JeuxConsole> JeuxConsole { get; set; } = default!;
        public DbSet<API_Console_Jeux.Models.Ventes> Ventes { get; set; } = default!;
        public DbSet<API_Console_Jeux.Models.Constructeur> Constructeur { get; set; } = default!;

    }
}
