namespace API_Console_Jeux.Models
{
    public class JeuxConsole
    {
        public int Id { get; set; }
        public string Nom_jeuxconsole { get; set; }
        public string Type_jeuxconsole { get; set; }
        public List<Ventes> List_ventes { get; set; }
    }
}
