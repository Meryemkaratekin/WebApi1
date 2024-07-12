using Microsoft.EntityFrameworkCore;
using RedbullService.Data;
using RedbullService.Models;
using RedbullService.Repositories;
using RedBullService.Models;
using System.Threading.Tasks;

namespace RedbullService.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly DataContext _context;

        public CommentRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Product> GetProductById(int productId)
        {
            return await _context.Products.FindAsync(productId);
        }

        public async Task<User> GetUserById(int userId)
        {
            return await _context.Users.FindAsync(userId);
        }

        public async Task<Comment> AddComment(Comment comment)
        {
            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();
            return comment;
        }
    }
}
