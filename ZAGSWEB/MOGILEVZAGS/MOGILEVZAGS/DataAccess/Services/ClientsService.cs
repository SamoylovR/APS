using Microsoft.EntityFrameworkCore;
using MOGILEVZAGS.DataAccess.Models;

namespace MOGILEVZAGS.DataAccess.Services
{
    public class ClientsService : IClientsService
    {
        private readonly DBContext _dbContext;
        private readonly ILogger<ClientsService> _logger;

        public ClientsService(
            DBContext dbContext,
            ILogger<ClientsService> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<List<Client>> GetDivorcedClientAsync() 
        {
            return await _dbContext.Clients.Where(item=>item.TypeOfOperation == "Divorce").ToListAsync();
        }

        public async Task<List<Client>> GetMarriagedClientAsync()
        {
            return await _dbContext.Clients.Where(item => item.TypeOfOperation == "Marriage").ToListAsync();
        }

        public async Task<List<Client>> GetAllClientsAsync()
        {
            return await _dbContext.Clients.ToListAsync();
        }
    }
}
