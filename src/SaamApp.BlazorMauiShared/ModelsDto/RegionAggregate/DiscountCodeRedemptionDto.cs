using System;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;

namespace SaamApp.Domain.ModelsDto
{
    public class DiscountCodeRedemptionDto
    {
        public DiscountCodeRedemptionDto() { } // AutoMapper required

        public DiscountCodeRedemptionDto(Guid customerId, Guid discountCodeId, DateTime discountCodeRedemptionDate)
        {
            CustomerId = Guard.Against.NullOrEmpty(customerId, nameof(customerId));
            DiscountCodeId = Guard.Against.NullOrEmpty(discountCodeId, nameof(discountCodeId));
            DiscountCodeRedemptionDate =
                Guard.Against.OutOfSQLDateRange(discountCodeRedemptionDate, nameof(discountCodeRedemptionDate));
        }

        public int RowId { get; set; }

        [Required(ErrorMessage = "Discount Code Redemption Date is required")]
        public DateTime DiscountCodeRedemptionDate { get; set; }

        public CustomerDto Customer { get; set; }

        [Required(ErrorMessage = "Customer is required")]
        public Guid CustomerId { get; set; }

        public DiscountCodeDto DiscountCode { get; set; }

        [Required(ErrorMessage = "Discount Code is required")]
        public Guid DiscountCodeId { get; set; }
    }
}