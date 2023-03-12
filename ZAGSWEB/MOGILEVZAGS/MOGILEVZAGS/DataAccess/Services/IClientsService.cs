using MOGILEVZAGS.DataAccess.Models;

namespace MOGILEVZAGS.DataAccess.Services
{
    public interface IClientsService
    {
        public Task<List<Client>> GetAllClientsAsync();

        public Task<List<Client>> GetMarriagedClientAsync();

        public Task<List<Client>> GetDivorcedClientAsync();
    }
}