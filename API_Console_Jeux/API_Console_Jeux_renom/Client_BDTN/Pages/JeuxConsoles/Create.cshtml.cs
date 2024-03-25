using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Client_BDTN.API;

namespace Client_BDTN.Pages.JeuxConsoles
{
    public class CreateModel : PageModel
    {
        private readonly IProjetClient _client;

        public CreateModel(IProjetClient client)
        {
            _client = client;
        }

        [BindProperty]
        public JeuxConsole JeuxConsole { get; set; } = new JeuxConsole();

        // Initialisez ici la liste des ventes pour le binding avec la vue.
        [BindProperty]
        public List<Ventes> Ventes { get; set; } = new List<Ventes>() { new Ventes() };

        public IActionResult OnGet()
        {
            // Initialisation supplémentaire si nécessaire
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Ajoutez les ventes au JeuxConsole avant de l'envoyer
            JeuxConsole.List_ventes = Ventes;

            try
            {
                await _client.JeuxConsolesPOSTAsync(JeuxConsole);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Une erreur est survenue: {ex.Message}");
                return Page();
            }
            return RedirectToPage("./Index");
        }
    }
}
