namespace RedbullService.DTOs
{
    public class ProductDto
    {
        public int product_id { get; set; }
        public string product_name { get; set; }
        public float price { get; set; }
        public string img_url { get; set; }
        public string description { get; set; }
        public int category_id { get; set; }

        public int quantity { get; set; } // ürünün sepetteki miktarı 
    }
}
