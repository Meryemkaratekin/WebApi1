using Microsoft.AspNetCore.Mvc;
using RedbullService.DTOs;
using RedbullService.Interfaces;
using System;
using System.Threading.Tasks;

namespace RedbullService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketRepository _basketRepository;

        public BasketController(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository ?? throw new ArgumentNullException(nameof(basketRepository));
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetBasket(int userId)
        {
            var basket = await _basketRepository.GetBasketDetails(userId);

            if (basket == null)
                return NotFound();

            return Ok(basket);
        }

        [HttpPost("{userId}/add/{productId}")]
        public async Task<IActionResult> AddToBasket(int userId, int productId)
        {
            var basket = await _basketRepository.AddToBasket(userId, productId);

            if (basket == null)
                return BadRequest();

            return Ok(basket);
        }

        [HttpDelete("{userId}/remove/{productId}")]
        public async Task<IActionResult> RemoveFromBasket(int userId, int productId)
        {
            var basket = await _basketRepository.RemoveFromBasket(userId, productId);

            if (basket == null)
                return NotFound();

            return Ok(basket);
        }

        [HttpDelete("{userId}/delete")]
        public async Task<IActionResult> DeleteBasket(int userId)
        {
            var result = await _basketRepository.DeleteBasket(userId);

            if (!result)
                return NotFound();

            return Ok();
        }
    }
}
