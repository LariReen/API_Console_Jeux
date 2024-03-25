using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Client_BDTN.API;

namespace Client_BDTN.Pages.JeuxConsoles
{
    public class EditModel : PageModel
    {
        private readonly IProjetClient _client;

        public EditModel(IProjetClient client)
        {
            _client = client;
        }

        [BindProperty]
        public JeuxConsole JeuxConsole { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jeuxConsole = await _client.JeuxConsolesGETAsync(id.Value);
            if (jeuxConsole == null)
            {
                return NotFound();
            }
            JeuxConsole = jeuxConsole;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            try
            {
                await _client.JeuxConsolesPUTAsync(JeuxConsole.Id, JeuxConsole);
            }
            catch (Exception ex)
            {
                return RedirectToPage("./Index");
            }
            return RedirectToPage("./Index");
        }
    }
}
