namespace RedbullService.DTOs
{
    public class CommentDto
    {
        public int id { get; set; }
        public string description { get; set; }
        public int rate { get; set; }
        public int user_id { get; set; }
        public int product_id { get; set; }
    }
}
