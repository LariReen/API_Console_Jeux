namespace API_Console_Jeux.Models
{
    public class Console
    {
        public int Id { get; set; }
        public string Nom_console { get; set; }
        public string Type_console { get; set; }
        public List<Ventes> List_ventes { get; set; }
    }
}
