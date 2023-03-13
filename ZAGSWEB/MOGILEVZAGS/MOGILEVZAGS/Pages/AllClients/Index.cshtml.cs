using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MOGILEVZAGS.DataAccess.Models;
using MOGILEVZAGS.DataAccess.Services;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;

namespace MOGILEVZAGS.Pages.AllClients
{
    [Authorize(Policy = "MustBeEmployee")]
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
                ListClients = await _clientService.GetAllClientsAsync();

            }
            catch (Exception ex)
            {

                _logger.LogError("Exception  " + ex.ToString());
            }
        }
        public async Task OnPost(int id)
        {
            await _clientService.DeleteClientById(id);
        }
    }
}
