using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MOGILEVZAGS.DataAccess;
using MOGILEVZAGS.DataAccess.Models;
using System.Security.Claims;

namespace MOGILEVZAGS.Pages.Employees
{
    [Authorize(Policy = "MustBeAdmin")]
    public class IndexModel : PageModel
    {
        private readonly DBContext _dbContext;
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(
            DBContext clientService,
            ILogger<IndexModel> logger)
        {
            _dbContext = clientService;
            _logger = logger;
        }

        public List<Employee> ListClients = new List<Employee>();

        public async Task OnGet()
        {
            try
            {
                ListClients = await _dbContext.Employees
                    .Include(item=>item.Positions)
                    .Include(item=>item.Location)
                    .ToListAsync();

            }
            catch (Exception ex)
            {

                _logger.LogError("Exception  " + ex.ToString());
            }
        }

        public async Task OnPost(int id) 
        {
            var employeeToDelete = await _dbContext.Employees
                .FirstOrDefaultAsync(item => item.Id == id);

            _dbContext.Employees.Remove(employeeToDelete);

            await _dbContext.SaveChangesAsync();
        }
    }
}
