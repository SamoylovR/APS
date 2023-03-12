using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MOGILEVZAGS.Pages
{
    public class ContactsModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;

        public ContactsModel(ILogger<PrivacyModel> logger)
        {
            _logger = logger;
        }
        public void OnGet()
        {
        }
    }
}
