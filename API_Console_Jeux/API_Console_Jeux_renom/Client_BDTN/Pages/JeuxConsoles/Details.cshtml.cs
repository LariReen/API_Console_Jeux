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
    public class DetailsModel : PageModel
    {
        private readonly IProjetClient _client;

        public DetailsModel(IProjetClient client)
        {
            _client = client;
        }

        public JeuxConsole JeuxConsole { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            JeuxConsole = await _client.JeuxConsolesGETAsync(id.Value);

            if (JeuxConsole == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
