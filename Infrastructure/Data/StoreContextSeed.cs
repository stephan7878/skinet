using System.Text.Json;
using Core.Entities;

namespace Infrastructure.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context)
        {
            // Brands
            if (!context.ProductBrands.Any())
            {
                var brandsData = File.ReadAllText("../Infrastructure/Data/SeedData/brands.json");
                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);
                
                foreach (var item in brands)
                {
                    context.Add(item);
                }

                await context.SaveChangesAsync();
            }

            // Types
            if (!context.ProductTypes.Any())
            {
                var typesData = File.ReadAllText("../Infrastructure/Data/SeedData/types.json");
                var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);
                
                foreach (var item in types)
                {
                    context.Add(item);
                }

                await context.SaveChangesAsync();
            }

            // Products
            if (!context.Products.Any())
            {
                var productsData = File.ReadAllText("../Infrastructure/Data/SeedData/products.json");
                var products = JsonSerializer.Deserialize<List<Product>>(productsData);
                
                foreach (var item in products)
                {
                    context.Add(item);
                }

                await context.SaveChangesAsync();
            }
        }
    }
}