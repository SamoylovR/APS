using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MOGILEVZAGS.DataAccess;
using MOGILEVZAGS.DataAccess.Models;
using MOGILEVZAGS.DataAccess.Services;

namespace MOGILEVZAGS.Pages.Clients
{
    public class IndexModel : PageModel
    {
        private readonly IClientsService _clientService;
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(
            IClientsService clientService,
            ILogger<IndexModel> logger)
        {
            _clientService = clientService;
            _logger = logger;
        }

        public List<Client> ListClients = new List<Client>();

        public async Task OnGet()
        {
            try
            {
                ListClients = await _clientService.GetMarriagedClientAsync();
            }
            catch (Exception ex)
            {

                _logger.LogError("Exception  " + ex.ToString());
            }
        }
    }
}
