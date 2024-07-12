using Microsoft.AspNetCore.Mvc;
using RedbullService.DTOs;
using RedbullService.Models;
using RedbullService.Repositories;
using RedBullService.Models;
using System.Threading.Tasks;

namespace RedbullService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentRepository _commentRepository;

        public CommentsController(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        [HttpPost("{productId}/comments")]
        public async Task<ActionResult<Comment>> PostComment(int productId, CommentDto commentDto)
        {
            var product = await _commentRepository.GetProductById(productId);

            if (product == null)
            {
                return NotFound(new { message = "Product not found." });
            }

            var user = await _commentRepository.GetUserById(commentDto.user_id);

            if (user == null)
            {
                return NotFound(new { message = "User not found." });
            }

            var comment = new Comment
            {
                description = commentDto.description,
                rate = commentDto.rate,
                user_id = commentDto.user_id,
                product_id = productId,
                User = user,
                Product = product
            };

            await _commentRepository.AddComment(comment);

            return CreatedAtAction(nameof(GetProductById), new { id = productId }, comment);
        }

        [HttpGet("{id}", Name = "GetProductById")]
        public async Task<ActionResult<Product>> GetProductById(int id)
        {
            var product = await _commentRepository.GetProductById(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }
    }
}
