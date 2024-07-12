using System.Threading.Tasks;
using RedbullService.Models;
using RedBullService.Models;

namespace RedbullService.Repositories
{
    public interface ICommentRepository
    {
        Task<Product> GetProductById(int productId);
        Task<User> GetUserById(int userId);
        Task<Comment> AddComment(Comment comment);
    }
}
