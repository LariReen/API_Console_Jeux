﻿namespace API_Console_Jeux.Models
{
    public class Constructeur
    {
        public int Id { get; set; }
        public string Nom_constructeur { get; set; }

        public List<JeuxConsole> List_console { get; set; }
    }
}
