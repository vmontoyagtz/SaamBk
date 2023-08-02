using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.SerfinsaPayment
{
    public class UpdateSerfinsaPaymentRequest : BaseRequest
    {
        public Guid SerfinsaPaymentId { get; set; }
        public Guid CustomerId { get; set; }
        public Guid DiscountCodeId { get; set; }
        public Guid PrepaidPackageId { get; set; }
        public string SerfinsaPaymentAmount { get; set; }
        public string SerfinsaPaymentTime { get; set; }
        public string SerfinsaPaymentDate { get; set; }
        public string SerfinsaPaymentReferenceNumber { get; set; }
        public string SerfinsaPaymentAuditNo { get; set; }
        public string SerfinsaPaymentTimeMessageType { get; set; }
        public string? SerfinsaPaymentTimeAuthorize { get; set; }
        public string SerfinsaPaymentTimeAnswer { get; set; }
        public string SerfinsaPaymentTimeType { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid? UpdatedBy { get; set; }
        public bool? IsDeleted { get; set; }
        public Guid TenantId { get; set; }

        public static UpdateSerfinsaPaymentRequest FromDto(SerfinsaPaymentDto serfinsaPaymentDto)
        {
            return new UpdateSerfinsaPaymentRequest
            {
                SerfinsaPaymentId = serfinsaPaymentDto.SerfinsaPaymentId,
                CustomerId = serfinsaPaymentDto.CustomerId,
                DiscountCodeId = serfinsaPaymentDto.DiscountCodeId,
                PrepaidPackageId = serfinsaPaymentDto.PrepaidPackageId,
                SerfinsaPaymentAmount = serfinsaPaymentDto.SerfinsaPaymentAmount,
                SerfinsaPaymentTime = serfinsaPaymentDto.SerfinsaPaymentTime,
                SerfinsaPaymentDate = serfinsaPaymentDto.SerfinsaPaymentDate,
                SerfinsaPaymentReferenceNumber = serfinsaPaymentDto.SerfinsaPaymentReferenceNumber,
                SerfinsaPaymentAuditNo = serfinsaPaymentDto.SerfinsaPaymentAuditNo,
                SerfinsaPaymentTimeMessageType = serfinsaPaymentDto.SerfinsaPaymentTimeMessageType,
                SerfinsaPaymentTimeAuthorize = serfinsaPaymentDto.SerfinsaPaymentTimeAuthorize,
                SerfinsaPaymentTimeAnswer = serfinsaPaymentDto.SerfinsaPaymentTimeAnswer,
                SerfinsaPaymentTimeType = serfinsaPaymentDto.SerfinsaPaymentTimeType,
                CreatedAt = serfinsaPaymentDto.CreatedAt,
                CreatedBy = serfinsaPaymentDto.CreatedBy,
                UpdatedAt = serfinsaPaymentDto.UpdatedAt,
                UpdatedBy = serfinsaPaymentDto.UpdatedBy,
                IsDeleted = serfinsaPaymentDto.IsDeleted,
                TenantId = serfinsaPaymentDto.TenantId
            };
        }
    }
}