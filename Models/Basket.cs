using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RedbullService.Models
{
    public class Basket
    {
        [Key]
        public int basket_id { get; set; }
        
        public int user_id { get; set; }
        public User User { get; set; }
        

        // Basket ile BasketProducts arasındaki ilişkiyi tanımlayın
        public ICollection<BasketProduct> BasketProducts { get; set; }
    }
}



