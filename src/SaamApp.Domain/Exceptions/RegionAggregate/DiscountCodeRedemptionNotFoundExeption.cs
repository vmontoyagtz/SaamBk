using System;

namespace SaamApp.Domain.Exceptions
{
    public class DiscountCodeRedemptionNotFoundException : Exception
    {
        public DiscountCodeRedemptionNotFoundException(string message) : base(message)
        {
        }

        public DiscountCodeRedemptionNotFoundException(int rowId) : base(
            $"No discountCodeRedemption with id {rowId} found.")
        {
        }
    }
}