using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Client_BDTN.API;

namespace Client_BDTN.Pages.Vente
{
    public class DetailsModel : PageModel
    {
        private readonly IProjetClient _client;

        public DetailsModel(IProjetClient client)
        {
            _client = client;
        }

        public Ventes Ventes { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Ventes = await _client.VentesGETAsync(id.Value);

            if (Ventes == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
