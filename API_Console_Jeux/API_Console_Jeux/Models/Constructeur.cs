namespace API_Console_Jeux.Models
{
    public class Constructeur
    {
        public int Id_constructeur { get; set; }
        public string Nom_constructeur { get; set; }

        public List<Console> List_console { get; set; }
    }
}
