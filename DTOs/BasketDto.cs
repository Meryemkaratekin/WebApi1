namespace RedbullService.DTOs
{
    public class BasketDto
    {
        public int UserId { get; set; }
        public ICollection<ProductDto> Products { get; set; }
        public float Total { get; set; }
        public int TotalProduct { get; set; } // Sepetteki toplam ürün sayısı
        public float TotalAmount { get; set; } // Sepetin toplam tutarı
    }
}
