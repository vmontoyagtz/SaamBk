using System;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;

namespace SaamApp.Domain.ModelsDto
{
    public class PrepaidPackageRedemptionDto
    {
        public PrepaidPackageRedemptionDto() { } // AutoMapper required

        public PrepaidPackageRedemptionDto(Guid prepaidPackageRedemptionId, Guid customerId, Guid prepaidPackageId,
            decimal prepaidPackageAmount, DateTime prepaidPackageRedemptionDate)
        {
            PrepaidPackageRedemptionId =
                Guard.Against.NullOrEmpty(prepaidPackageRedemptionId, nameof(prepaidPackageRedemptionId));
            CustomerId = Guard.Against.NullOrEmpty(customerId, nameof(customerId));
            PrepaidPackageId = Guard.Against.NullOrEmpty(prepaidPackageId, nameof(prepaidPackageId));
            PrepaidPackageAmount = Guard.Against.Negative(prepaidPackageAmount, nameof(prepaidPackageAmount));
            PrepaidPackageRedemptionDate =
                Guard.Against.OutOfSQLDateRange(prepaidPackageRedemptionDate, nameof(prepaidPackageRedemptionDate));
        }

        public Guid PrepaidPackageRedemptionId { get; set; }

        [Required(ErrorMessage = "Prepaid Package Amount is required")]
        public decimal PrepaidPackageAmount { get; set; }

        [Required(ErrorMessage = "Prepaid Package Redemption Date is required")]
        public DateTime PrepaidPackageRedemptionDate { get; set; }

        public CustomerDto Customer { get; set; }

        [Required(ErrorMessage = "Customer is required")]
        public Guid CustomerId { get; set; }

        public PrepaidPackageDto PrepaidPackage { get; set; }

        [Required(ErrorMessage = "Prepaid Package is required")]
        public Guid PrepaidPackageId { get; set; }
    }
}