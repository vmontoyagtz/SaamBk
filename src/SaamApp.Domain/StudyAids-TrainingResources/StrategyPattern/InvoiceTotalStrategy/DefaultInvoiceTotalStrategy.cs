using System;
using System.Linq;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.StudyAids_TrainingResources.StrategyPattern.InvoiceTotalStrategy
{
    public interface IInvoiceTotalStrategy
    {
        decimal CalculateTotal(Invoice invoice);
        decimal CalculateTax(Invoice invoice);
    }

    public class DefaultInvoiceTotalStrategy : IInvoiceTotalStrategy
    {
        public decimal CalculateTotal(Invoice invoice)
        {
            return invoice.InvoiceDetails.Sum(id => id.LineSale) ?? 0;
        }

        public decimal CalculateTax(Invoice invoice)
        {
            var totalSale = CalculateTotal(invoice);
            return totalSale * 0.1m;
        }
    }

    public class TaxFreeInvoiceTotalStrategy : IInvoiceTotalStrategy
    {
        public decimal CalculateTotal(Invoice invoice)
        {
            return invoice.InvoiceDetails.Sum(id => id.LineSale) ?? 0;
        }

        public decimal CalculateTax(Invoice invoice)
        {
            return 0;
        }
    }

    public class BulkDiscountInvoiceTotalStrategy : IInvoiceTotalStrategy
    {
        private const int QuantityThreshold = 100;
        private const decimal DiscountRate = 0.05m;

        public decimal CalculateTotal(Invoice invoice)
        {
            var totalSale = invoice.InvoiceDetails.Sum(id => id.LineSale) ?? 0;
            var totalQuantity = invoice.InvoiceDetails.Sum(id => id.Quantity);
            if (totalQuantity > QuantityThreshold)
            {
                totalSale *= 1 - DiscountRate;
            }

            return totalSale;
        }

        public decimal CalculateTax(Invoice invoice)
        {
            var totalSale = CalculateTotal(invoice);
            return totalSale * 0.1m;
        }
    }

    public class SeasonalDiscountInvoiceTotalStrategy : IInvoiceTotalStrategy
    {
        private const decimal DiscountRate = 0.1m;

        public decimal CalculateTotal(Invoice invoice)
        {
            var totalSale = invoice.InvoiceDetails.Sum(id => id.LineSale) ?? 0;
            if (IsDiscountSeason())
            {
                totalSale *= 1 - DiscountRate;
            }

            return totalSale;
        }

        public decimal CalculateTax(Invoice invoice)
        {
            var totalSale = CalculateTotal(invoice);
            return totalSale * 0.1m;
        }

        private bool IsDiscountSeason()
        {
            return DateTime.Now.Month == 12;
        }
    }
}