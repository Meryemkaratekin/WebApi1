using RedbullService.Models;
using RedBullService.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RedbullService.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProducts();
        Task<Product> GetProductByID(int id);
        Task AddProduct(Product product);
        Task UpdateProduct(Product product);
        Task DeleteProduct(int productId);
    }
}
