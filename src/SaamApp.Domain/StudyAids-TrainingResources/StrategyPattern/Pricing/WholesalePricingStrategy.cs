using SaamApp.Domain.Entities;

namespace SaamApp.Domain.TeachingMaterial.Strategies.Pricing
{
    public class WholesalePricingStrategy : IPricingStrategy
    {
        public decimal? CalculatePrice(Product product)
        {
            return product.ProductUnitPrice * 0.9m;
        }
    }
}