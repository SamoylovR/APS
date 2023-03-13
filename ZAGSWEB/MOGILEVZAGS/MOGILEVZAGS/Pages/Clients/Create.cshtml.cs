using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MOGILEVZAGS.DataAccess;
using MOGILEVZAGS.DataAccess.Models;
using System.Data.SqlClient;

namespace MOGILEVZAGS.Pages.Clients
{
    public class CreateModel : PageModel
    {
        private readonly DBContext _dbContext;

        public Client clientInfo = new Client();

        public String errorMessage = "";
        public String successMessage = "";

        public CreateModel(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void OnGet()
        {
        }
        
        public async Task OnPost()
        {
            clientInfo.Name = Request.Form["name"];
            clientInfo.Patronymic = Request.Form["surname"];
            clientInfo.SecondName = Request.Form["secondname"];
            clientInfo.Email = Request.Form["email"];
            clientInfo.Phone = Request.Form["phone"];

            clientInfo.TypeOfOperation = "Marriage";

            var marriage = new Marriage
            {
                Client = clientInfo,
            };

            await _dbContext.Marriages.AddAsync(marriage);
            await _dbContext.SaveChangesAsync();

            Response.Redirect("/Clients/Index");
        }
    }
}