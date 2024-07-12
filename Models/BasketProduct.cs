using RedBullService.Models;
using System.ComponentModel.DataAnnotations;

namespace RedbullService.Models
{
    public class BasketProduct
    {
        [Key]
        public int BasketProductId { get; set; }
        public int basket_id { get; set; }
        public Basket basket;

        public int product_id { get; set; }
        public Product product { get; set; }

        public int quantity { get; set; }
    }
}