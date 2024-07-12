using RedBullService.Models;
using System.ComponentModel.DataAnnotations;

namespace RedbullService.Models
{
    public class Category
    {
        [Key]
        public int category_id {get; set;}
        [Required]
        public String category_name { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
