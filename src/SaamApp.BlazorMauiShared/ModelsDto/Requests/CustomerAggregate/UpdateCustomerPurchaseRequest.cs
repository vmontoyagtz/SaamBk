using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.CustomerPurchase
{
    public class UpdateCustomerPurchaseRequest : BaseRequest
    {
        public Guid CustomerPurchaseId { get; set; }
        public Guid CustomerId { get; set; }
        public Guid ReferenceId { get; set; }
        public string ReferenceIdDescription { get; set; }
        public decimal TransactionAmount { get; set; }
        public decimal CustomerPurchaseTotal { get; set; }
        public bool IsPositive { get; set; }
        public bool IsNegative { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid? UpdatedBy { get; set; }
        public bool? IsDeleted { get; set; }

        public static UpdateCustomerPurchaseRequest FromDto(CustomerPurchaseDto customerPurchaseDto)
        {
            return new UpdateCustomerPurchaseRequest
            {
                CustomerPurchaseId = customerPurchaseDto.CustomerPurchaseId,
                CustomerId = customerPurchaseDto.CustomerId,
                ReferenceId = customerPurchaseDto.ReferenceId,
                ReferenceIdDescription = customerPurchaseDto.ReferenceIdDescription,
                TransactionAmount = customerPurchaseDto.TransactionAmount,
                CustomerPurchaseTotal = customerPurchaseDto.CustomerPurchaseTotal,
                IsPositive = customerPurchaseDto.IsPositive,
                IsNegative = customerPurchaseDto.IsNegative,
                CreatedAt = customerPurchaseDto.CreatedAt,
                CreatedBy = customerPurchaseDto.CreatedBy,
                UpdatedAt = customerPurchaseDto.UpdatedAt,
                UpdatedBy = customerPurchaseDto.UpdatedBy,
                IsDeleted = customerPurchaseDto.IsDeleted
            };
        }
    }
}