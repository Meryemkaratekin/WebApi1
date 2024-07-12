using System.ComponentModel.DataAnnotations;

namespace RedbullService.Models
{
    public class User
    {
        [Key]
        public int user_id { get; set; }
        public String username { get; set; }
        public String email { get; set; }
        public String password { get; set; }
        public String phone_number { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
