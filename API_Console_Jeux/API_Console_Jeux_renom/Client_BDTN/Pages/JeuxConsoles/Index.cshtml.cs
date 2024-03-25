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
    public class IndexModel : PageModel
    {
        private readonly IProjetClient _client;

        public IndexModel(IProjetClient client)
        {
            _client = client;
        }

        public IList<JeuxConsole> JeuxConsole { get;set; } = default!;

        public async Task OnGetAsync()
        {
            JeuxConsole = (await _client.JeuxConsolesAllAsync()).ToList();
        }
    }
}
