using RedbullService.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RedBullService.Models
{
    public class Product
    {
        [Key]
        public int product_id { get; set; }
        public String product_name { get; set; } 
        public float price { get; set; }
        public String img_url { get; set; }
        public String description { get; set; }
        public int category_id { get; set; }
        public Category Category { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}