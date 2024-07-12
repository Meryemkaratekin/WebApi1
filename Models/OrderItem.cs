using System.ComponentModel.DataAnnotations;

namespace RedbullService.Models
{
    public class OrderItem
    {
        [Key]
        public int OrderItemId { get; set; }
        public int product_id { get; set; }
        public int Quantity { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
