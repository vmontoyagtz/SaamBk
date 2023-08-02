using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AdvisorPayment
{
    public class UpdateAdvisorPaymentRequest : BaseRequest
    {
        public int RowId { get; set; }
        public Guid AdvisorId { get; set; }
        public Guid BankAccountId { get; set; }
        public Guid PaymentMethodId { get; set; }
        public string AdvisorPaymentDescription { get; set; }
        public decimal AdvisorPaymentsAmount { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid? UpdatedBy { get; set; }
        public bool? IsDeleted { get; set; }

        public static UpdateAdvisorPaymentRequest FromDto(AdvisorPaymentDto advisorPaymentDto)
        {
            return new UpdateAdvisorPaymentRequest
            {
                RowId = advisorPaymentDto.RowId,
                AdvisorId = advisorPaymentDto.AdvisorId,
                BankAccountId = advisorPaymentDto.BankAccountId,
                PaymentMethodId = advisorPaymentDto.PaymentMethodId,
                AdvisorPaymentDescription = advisorPaymentDto.AdvisorPaymentDescription,
                AdvisorPaymentsAmount = advisorPaymentDto.AdvisorPaymentsAmount,
                CreatedAt = advisorPaymentDto.CreatedAt,
                CreatedBy = advisorPaymentDto.CreatedBy,
                UpdatedAt = advisorPaymentDto.UpdatedAt,
                UpdatedBy = advisorPaymentDto.UpdatedBy,
                IsDeleted = advisorPaymentDto.IsDeleted
            };
        }
    }
}