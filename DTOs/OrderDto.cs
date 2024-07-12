namespace RedbullService.DTOs
{
    public class OrderDto
    {
        public int user_id { get; set; }
        public List<OrderItemDto> Items { get; set; }
        public string Status { get; set; }
    }
}
