using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MOGILEVZAGS.DataAccess.Models;
using MOGILEVZAGS.DataAccess.Services;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;


namespace MOGILEVZAGS.Pages.Client1
{
    public class Index1Model : PageModel
    {
        private readonly IClientsService _clientService;
        private readonly ILogger<IndexModel> _logger;

        public Index1Model(
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
                ListClients = await _clientService.GetDivorcedClientAsync();

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
