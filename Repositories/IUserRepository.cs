using VpnClient.Models;
using System.Threading.Tasks;

namespace VpnClient.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUserByUsernameAndPassword(string username, string password);
    }
}

