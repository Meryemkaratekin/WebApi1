using System.Threading.Tasks;
using RedbullService.Models;

namespace RedbullService.Repositories
{
    public interface IUserRepository
    {
        Task<User> Register(User user);
        Task<User> Login(string email, string password);
        Task<User> UpdateUser(User user);
        Task<User> GetUserById(int userId);
    }
}
