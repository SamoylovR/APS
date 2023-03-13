using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MOGILEVZAGS.DataAccess;
using MOGILEVZAGS.DataAccess.Models;

namespace MOGILEVZAGS.Pages.Employees
{
    public class CreateModel : PageModel
    {
        private readonly DBContext _dbContext;

        public Employee employeeInfo = new Employee();

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
            employeeInfo.Name = Request.Form["name"];
            employeeInfo.Patronymic = Request.Form["patronymic"];
            employeeInfo.SecondName = Request.Form["secondname"];
            employeeInfo.Email = Request.Form["email"];
            employeeInfo.Phone = Request.Form["phone"];
            employeeInfo.Location = new Location { LocationName = Request.Form["location"] };
            employeeInfo.Positions = new List<Position>();
            var Positions = Request.Form["position"];
            employeeInfo.Positions.Add(new Position { Name = Positions });

            await _dbContext.Employees.AddAsync(employeeInfo);

            await _dbContext.SaveChangesAsync();

            Response.Redirect("/Employees/Index");
        }
    }
}
