using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MOGILEVZAGS.Pages.Auth
{
    public class logoutModel : PageModel
    {
        public async Task<IActionResult> OnPostAsync()
        {
            await HttpContext.SignOutAsync("ZagsCookie");

            return RedirectToPage("/Index");
        }
    }
}
