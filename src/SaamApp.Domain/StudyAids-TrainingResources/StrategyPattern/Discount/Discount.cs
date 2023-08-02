using System;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.TeachingMaterial.Strategies.Discount
{
    public interface IDiscountStrategy
    {
        decimal CalculateDiscount(InvoiceDetail invoiceDetail);
    }

    public class PowerBuyerDiscountStrategy : IDiscountStrategy
    {
        private const decimal Tier1Discount = 0.15m;
        private const decimal Tier2Discount = 0.2m;
        private const decimal Tier3Discount = 0.3m;

        public decimal CalculateDiscount(InvoiceDetail invoiceDetail)
        {
            decimal discount = 0;
            if (invoiceDetail.Quantity > 20)
            {
                discount = Tier3Discount;
            }
            else if (invoiceDetail.Quantity >= 10 && invoiceDetail.Quantity <= 20)
            {
                discount = Tier2Discount;
            }
            else if (invoiceDetail.Quantity >= 5 && invoiceDetail.Quantity < 10)
            {
                discount = Tier1Discount;
            }

            return discount;
        }
    }

    public class RegularCustomerDiscountStrategy : IDiscountStrategy
    {
        public decimal CalculateDiscount(InvoiceDetail invoiceDetail)
        {
            return 0;
        }
    }

    public class SpecialEventDiscountStrategy : IDiscountStrategy
    {
        private readonly decimal _discountPercentage;
        private readonly DateTime _eventDate;

        public SpecialEventDiscountStrategy(DateTime eventDate, decimal discountPercentage)
        {
            _eventDate = eventDate;
            _discountPercentage = discountPercentage;
        }

        public decimal CalculateDiscount(InvoiceDetail invoiceDetail)
        {
            if (invoiceDetail == null)
            {
                return 0;
            }

            if (invoiceDetail.Invoice.InvoicedDate.HasValue &&
                invoiceDetail.Invoice.InvoicedDate.Value == _eventDate.Date)
            {
                var discountAmount = invoiceDetail.LineSale * _discountPercentage / 100;
                if (discountAmount.HasValue && invoiceDetail.LineSale.HasValue)
                {
                    return Math.Min(discountAmount.Value, invoiceDetail.LineSale.Value);
                }
            }

            return 0;
        }
    }
}