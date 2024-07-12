using RedBullService.Models;
using System.ComponentModel.DataAnnotations;

namespace RedbullService.Models
{
    public class Comment
    {
        [Key]
        public int id { get; set; }
        public String description { get; set; }
        public int rate { get; set; }
        public int user_id { get; set; }
        public User User { get; set; }

        // Yorumun hangi ürüne ait olduğu
        public int product_id { get; set; }
        public Product Product { get; set; }
    }
}
