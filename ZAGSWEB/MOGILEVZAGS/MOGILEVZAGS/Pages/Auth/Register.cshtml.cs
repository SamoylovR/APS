using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MOGILEVZAGS.DataAccess;
using MOGILEVZAGS.DataAccess.Models;
using System.Security.Claims;

namespace MOGILEVZAGS.Pages.Auth
{
    public class RegisterModel : PageModel
    {
        [BindProperty]
        public User userModel { get; set; }
        private readonly DBContext _dBContext;

        public RegisterModel(DBContext dBContext)
        {
            _dBContext = dBContext;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            userModel.UserRole = Role.CommonUser;

            var existingModel = await _dBContext.Users
                .AddAsync(userModel);

            if (existingModel is not null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, $"{existingModel.Entity.Login}"),
                    new Claim(ClaimTypes.Email, $"{existingModel.Entity.Email}"),
                    new Claim(ClaimTypes.Role, $"{existingModel.Entity.UserRole}")
                };

                var identity = new ClaimsIdentity(claims, "ZagsCookie");
                var claimsPrincipal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync("ZagsCookie", claimsPrincipal);

                return RedirectToPage("/");
            }

            return Page();
        }
    }
}
