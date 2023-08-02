using SaamApp.Domain.Entities;

namespace SaamApp.Domain.TeachingMaterial.Strategies.Pricing
{
    public class RetailPricingStrategy : IPricingStrategy
    {
        public decimal? CalculatePrice(Product product)
        {
            return product.ProductUnitPrice;
        }
    }
}