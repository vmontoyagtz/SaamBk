using System;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;

namespace SaamApp.Domain.ModelsDto
{
    public class GiftCodeRedemptionDto
    {
        public GiftCodeRedemptionDto() { } // AutoMapper required

        public GiftCodeRedemptionDto(Guid giftCodeRedemptionId, Guid customerId, Guid giftCodeId,
            DateTime giftCodeRedemptionDate)
        {
            GiftCodeRedemptionId = Guard.Against.NullOrEmpty(giftCodeRedemptionId, nameof(giftCodeRedemptionId));
            CustomerId = Guard.Against.NullOrEmpty(customerId, nameof(customerId));
            GiftCodeId = Guard.Against.NullOrEmpty(giftCodeId, nameof(giftCodeId));
            GiftCodeRedemptionDate =
                Guard.Against.OutOfSQLDateRange(giftCodeRedemptionDate, nameof(giftCodeRedemptionDate));
        }

        public Guid GiftCodeRedemptionId { get; set; }

        [Required(ErrorMessage = "Gift Code Redemption Date is required")]
        public DateTime GiftCodeRedemptionDate { get; set; }

        public CustomerDto Customer { get; set; }

        [Required(ErrorMessage = "Customer is required")]
        public Guid CustomerId { get; set; }

        public GiftCodeDto GiftCode { get; set; }

        [Required(ErrorMessage = "Gift Code is required")]
        public Guid GiftCodeId { get; set; }
    }
}