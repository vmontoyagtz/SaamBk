using System;

namespace SaamApp.Domain.Exceptions
{
    public class DiscountCodeNotFoundException : Exception
    {
        public DiscountCodeNotFoundException(string message) : base(message)
        {
        }

        public DiscountCodeNotFoundException(Guid discountCodeId) : base(
            $"No discountCode with id {discountCodeId} found.")
        {
        }
    }
}