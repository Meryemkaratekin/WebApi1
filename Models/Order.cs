using System.ComponentModel.DataAnnotations;

namespace RedbullService.Models
{
    public class Order
    {

        [Key]
        public int OrderId { get; set; }
        public int user_id { get; set; }
        public string Status { get; set; }
        public ICollection<OrderItem> Items { get; set; }
    }
}
