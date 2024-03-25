using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Client_BDTN.API;

namespace Client_BDTN.Pages.JeuxConsoles
{
    public class DeleteModel : PageModel
    {
        private readonly IProjetClient _client;

        public DeleteModel(IProjetClient client)
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

            JeuxConsole= await _client.JeuxConsolesGETAsync(id.Value);

            if (JeuxConsole == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            try
            {
                await _client.JeuxConsolesDELETEAsync(id.Value);
            }
            catch (Exception ex)
            {
                return RedirectToPage("./Index");
            }
            return RedirectToPage("./Index");
        }

    }
}
