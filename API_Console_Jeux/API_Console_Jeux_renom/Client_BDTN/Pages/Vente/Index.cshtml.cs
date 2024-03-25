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
    public class IndexModel : PageModel
    {
        private readonly IProjetClient _client;

        public IndexModel(IProjetClient client)
        {
            _client = client;
        }

        public IList<Ventes> Ventes { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Ventes = (await _client.VentesAllAsync()).ToList();
        }
    }
}
