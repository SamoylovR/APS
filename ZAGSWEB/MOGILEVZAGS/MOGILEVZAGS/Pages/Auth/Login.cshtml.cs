using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MOGILEVZAGS.DataAccess;
using MOGILEVZAGS.DataAccess.Models;
using System.Security.Claims;

namespace MOGILEVZAGS.Pages.Auth
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public User userModel { get; set; }

        private readonly DBContext _dBContext;

        public LoginModel(DBContext dBContext)
        {
            _dBContext = dBContext;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            var existingModel = await _dBContext.Users
                .FirstOrDefaultAsync(item => item.Login == userModel.Login
                    && item.Password == userModel.Password);

            if (existingModel is not null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, $"{existingModel.Login}"),
                    new Claim(ClaimTypes.Email, $"{existingModel.Email}"),
                    new Claim(ClaimTypes.Role, $"{existingModel.UserRole}")
                };

                var identity = new ClaimsIdentity(claims, "ZagsCookie");
                var claimsPrincipal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync("ZagsCookie", claimsPrincipal);

                return RedirectToPage("/Index");
            }

            return Page();
        }
    }
}
