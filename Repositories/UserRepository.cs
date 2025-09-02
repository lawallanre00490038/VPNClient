using VpnClient.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace VpnClient.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly List<User> _mockUsers = new List<User>
        {
            new User { Username = "admin", Email = "admin@example.com", Password = "password123" },
            new User { Username = "user1", Email = "user1@example.com", Password = "pass456" }
        };

        public async Task<User> GetUserByUsernameAndPassword(string username, string password)
        {
            // Simulate network delay
            await Task.Delay(100);
            return _mockUsers.FirstOrDefault(u => u.Username == username && u.Password == password);
        }
    }
}


// using VpnClient.Models;

