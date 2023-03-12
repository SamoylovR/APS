using MOGILEVZAGS.DataAccess.Models;

namespace MOGILEVZAGS.DataAccess.Services
{
    public interface IClientsService
    {
        public Task<List<Client>> GetAllClientsAsync();
    }
}
