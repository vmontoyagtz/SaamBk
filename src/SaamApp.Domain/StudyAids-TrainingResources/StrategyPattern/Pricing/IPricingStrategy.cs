using SaamApp.Domain.Entities;

namespace SaamApp.Domain.TeachingMaterial.Strategies.Pricing
{
    public interface IPricingStrategy
    {
        decimal? CalculatePrice(Product product);
    }
}