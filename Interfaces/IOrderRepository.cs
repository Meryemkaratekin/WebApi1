using System.Collections.Generic;
using System.Threading.Tasks;
using RedbullService.Models;


namespace RedbullService.Interfaces
{
    public interface IOrderRepository
    {

        Task<Order> CreateOrder(Order order);
        Task<Order> GetOrderById(int orderId);
        Task UpdateOrderStatus(int orderId, string status);
        Task<IEnumerable<Order>> GetAllOrders();
    }
}
