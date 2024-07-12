using Microsoft.EntityFrameworkCore;
using RedbullService.Data;
using RedbullService.DTOs;
using RedbullService.Interfaces;
using RedbullService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedbullService.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        private readonly DataContext _context;

        public BasketRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Basket> GetBasketByUserId(int userId)
        {
            return await _context.Baskets
                .Include(b => b.BasketProducts)
                .ThenInclude(bp => bp.product)
                .FirstOrDefaultAsync(b => b.user_id == userId);
        }

        public async Task<BasketDto> GetBasketDetails(int userId)
        {
            var basket = await _context.Baskets
                .Include(b => b.BasketProducts)
                .ThenInclude(bp => bp.product)
                .FirstOrDefaultAsync(b => b.user_id == userId);

            if (basket == null)
                return null;

            var basketDto = new BasketDto
            {
                UserId = basket.user_id,
                TotalProduct = basket.BasketProducts.Sum(bp => bp.quantity),
                TotalAmount = basket.BasketProducts.Sum(bp => bp.product.price * bp.quantity),
                Products = basket.BasketProducts.Select(bp => new ProductDto
                {
                    product_id = bp.product_id,
                    product_name = bp.product.product_name,
                    price = bp.product.price,
                    img_url = bp.product.img_url,
                    description = bp.product.description,
                    category_id = bp.product.category_id,
                    quantity = bp.quantity
                }).ToList()
            };

            return basketDto;
        }

        public async Task<Basket> AddToBasket(int userId, int productId)
        {
            var basket = await _context.Baskets
                .Include(b => b.BasketProducts)
                .FirstOrDefaultAsync(b => b.user_id == userId);

            if (basket == null)
            {
                basket = new Basket
                {
                    user_id = userId,
                    BasketProducts = new List<BasketProduct>()
                };
                _context.Baskets.Add(basket);
            }

            var product = await _context.Products.FindAsync(productId);
            if (product == null)
            {
                throw new InvalidOperationException("Product not found");
            }

            var basketProduct = basket.BasketProducts.FirstOrDefault(bp => bp.product_id == productId);
            if (basketProduct != null)
            {
                basketProduct.quantity++;
            }
            else
            {
                basket.BasketProducts.Add(new BasketProduct
                {
                    basket_id = basket.basket_id,
                    product_id = productId,
                    basket = basket,
                    product = product,
                    quantity = 1
                });
            }
            await _context.SaveChangesAsync();

            return basket;
        }

        public async Task<Basket> RemoveFromBasket(int userId, int productId)
        {
            var basket = await _context.Baskets
                .Include(b => b.BasketProducts)
                .FirstOrDefaultAsync(b => b.user_id == userId);

            if (basket != null)
            {
                var product = basket.BasketProducts.FirstOrDefault(bp => bp.product_id == productId);
                if (product != null)
                {
                    if (product.quantity > 1)
                    {
                        product.quantity--;
                    }
                    else
                    {
                        basket.BasketProducts.Remove(product);
                    }

                    await _context.SaveChangesAsync();
                }
            }

            return basket;
        }

        public async Task<bool> DeleteBasket(int userId)
        {
            var basket = await _context.Baskets.FirstOrDefaultAsync(b => b.user_id == userId);
            if (basket != null)
            {
                _context.Baskets.Remove(basket);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
