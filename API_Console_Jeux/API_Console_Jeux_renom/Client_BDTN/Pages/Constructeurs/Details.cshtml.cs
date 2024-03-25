using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Client_BDTN.API;

namespace Client_BDTN.Pages.Constructeurs
{
    public class DetailsModel : PageModel
    {
        private readonly IProjetClient _client;

        public DetailsModel(IProjetClient client)
        {
            _client = client;
        }

        public Constructeur Constructeur { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Constructeur = await _client.ConstructeursGETAsync(id.Value);

            if (Constructeur == null)
            {
                return NotFound();
            }
            return Page();
        }

    }
}
