using RedbullService.Data;
using RedBullService.Models;

namespace RedBullService
{
    public class Seed
    {
        private readonly DataContext dataContext;
        public Seed(DataContext context)
        {
            this.dataContext = context;
        }
        public void SeedDataContext()
        {
            if (!dataContext.Products.Any())
            {
                var Product = new Product()
                {
                    product_name = "Elbise",
                    price = 1500,
                    img_url = "asdfghjkl",
                    description = "elbise açıklaması"
                };
                
            }
        }
    }
}