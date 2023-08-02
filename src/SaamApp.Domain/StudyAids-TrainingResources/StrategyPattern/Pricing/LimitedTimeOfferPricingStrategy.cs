using System;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.TeachingMaterial.Strategies.Pricing
{
    public class LimitedTimeOfferPricingStrategy : IPricingStrategy
    {
        private readonly decimal _discountPercentage;
        private readonly DateTime _offerEndDate;
        private readonly DateTime _offerStartDate;

        public LimitedTimeOfferPricingStrategy(DateTime offerStartDate, DateTime offerEndDate,
            decimal discountPercentage)
        {
            _offerStartDate = offerStartDate;
            _offerEndDate = offerEndDate;
            _discountPercentage = discountPercentage;
        }

        public decimal? CalculatePrice(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }

            var currentDate = DateTime.Now;
            if (currentDate >= _offerStartDate && currentDate <= _offerEndDate)
            {
                var discountedPrice = product.ProductUnitPrice * (1 - _discountPercentage);
                return discountedPrice;
            }

            return product.ProductUnitPrice;
        }
    }
}