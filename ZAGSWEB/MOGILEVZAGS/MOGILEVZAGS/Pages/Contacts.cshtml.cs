using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MOGILEVZAGS.DataAccess;
using MOGILEVZAGS.DataAccess.Models;
using MOGILEVZAGS.Pages.Clients;

namespace MOGILEVZAGS.Pages
{
    public class ContactsModel : PageModel
    {
        private ContactForm contactForm;
        private readonly ILogger<PrivacyModel> _logger;
        private readonly DBContext _dBContext;

        public ContactsModel(
            ILogger<PrivacyModel> logger,
            DBContext dBContext)
        {
            _logger = logger;
            _dBContext = dBContext;
        }
        public void OnGet()
        {
        }

        public async Task OnPost()
        {
            contactForm = new ContactForm
            {
                Name = Request.Form["Name"],
                Message = Request.Form["Message"],
                Email = Request.Form["Email"],
            };

            await _dBContext.ContactForms.AddAsync(contactForm);
            await _dBContext.SaveChangesAsync();
        }
    }
}
