using RedbullService.DTOs;
using RedbullService.Models;
using System.Threading.Tasks;

namespace RedbullService.Interfaces
{
    public interface IBasketRepository
    {
        Task<Basket> GetBasketByUserId(int userId);
        Task<Basket> AddToBasket(int userId, int productId);
        Task<Basket> RemoveFromBasket(int userId, int productId);
        Task<bool> DeleteBasket(int userId);
        Task<BasketDto> GetBasketDetails(int userId); // Sepet detaylarını getiren metod
    }
}
