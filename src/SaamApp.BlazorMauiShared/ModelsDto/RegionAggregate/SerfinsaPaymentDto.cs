using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;

namespace SaamApp.Domain.ModelsDto
{
    public class SerfinsaPaymentDto
    {
        public SerfinsaPaymentDto() { } // AutoMapper required

        public SerfinsaPaymentDto(Guid serfinsaPaymentId, Guid customerId, Guid discountCodeId, Guid prepaidPackageId,
            string serfinsaPaymentAmount, string serfinsaPaymentTime, string serfinsaPaymentDate,
            string serfinsaPaymentReferenceNumber, string serfinsaPaymentAuditNo, string serfinsaPaymentTimeMessageType,
            string? serfinsaPaymentTimeAuthorize, string serfinsaPaymentTimeAnswer, string serfinsaPaymentTimeType,
            DateTime createdAt, Guid createdBy, DateTime? updatedAt, Guid? updatedBy, bool? isDeleted, Guid tenantId)
        {
            SerfinsaPaymentId = Guard.Against.NullOrEmpty(serfinsaPaymentId, nameof(serfinsaPaymentId));
            CustomerId = Guard.Against.NullOrEmpty(customerId, nameof(customerId));
            DiscountCodeId = Guard.Against.NullOrEmpty(discountCodeId, nameof(discountCodeId));
            PrepaidPackageId = Guard.Against.NullOrEmpty(prepaidPackageId, nameof(prepaidPackageId));
            SerfinsaPaymentAmount =
                Guard.Against.NullOrWhiteSpace(serfinsaPaymentAmount, nameof(serfinsaPaymentAmount));
            SerfinsaPaymentTime = Guard.Against.NullOrWhiteSpace(serfinsaPaymentTime, nameof(serfinsaPaymentTime));
            SerfinsaPaymentDate = Guard.Against.NullOrWhiteSpace(serfinsaPaymentDate, nameof(serfinsaPaymentDate));
            SerfinsaPaymentReferenceNumber = Guard.Against.NullOrWhiteSpace(serfinsaPaymentReferenceNumber,
                nameof(serfinsaPaymentReferenceNumber));
            SerfinsaPaymentAuditNo =
                Guard.Against.NullOrWhiteSpace(serfinsaPaymentAuditNo, nameof(serfinsaPaymentAuditNo));
            SerfinsaPaymentTimeMessageType = Guard.Against.NullOrWhiteSpace(serfinsaPaymentTimeMessageType,
                nameof(serfinsaPaymentTimeMessageType));
            SerfinsaPaymentTimeAuthorize = serfinsaPaymentTimeAuthorize;
            SerfinsaPaymentTimeAnswer =
                Guard.Against.NullOrWhiteSpace(serfinsaPaymentTimeAnswer, nameof(serfinsaPaymentTimeAnswer));
            SerfinsaPaymentTimeType =
                Guard.Against.NullOrWhiteSpace(serfinsaPaymentTimeType, nameof(serfinsaPaymentTimeType));
            CreatedAt = Guard.Against.OutOfSQLDateRange(createdAt, nameof(createdAt));
            CreatedBy = Guard.Against.NullOrEmpty(createdBy, nameof(createdBy));
            UpdatedAt = updatedAt;
            UpdatedBy = updatedBy;
            IsDeleted = isDeleted;
            TenantId = Guard.Against.NullOrEmpty(tenantId, nameof(tenantId));
        }

        public Guid SerfinsaPaymentId { get; set; }

        [Required(ErrorMessage = "Serfinsa Payment Amount is required")]
        [MaxLength(100)]
        public string SerfinsaPaymentAmount { get; set; }

        [Required(ErrorMessage = "Serfinsa Payment Time is required")]
        [MaxLength(100)]
        public string SerfinsaPaymentTime { get; set; }

        [Required(ErrorMessage = "Serfinsa Payment Date is required")]
        [MaxLength(100)]
        public string SerfinsaPaymentDate { get; set; }

        [Required(ErrorMessage = "Serfinsa Payment Reference Number is required")]
        [MaxLength(100)]
        public string SerfinsaPaymentReferenceNumber { get; set; }

        [Required(ErrorMessage = "Serfinsa Payment Audit No is required")]
        [MaxLength(100)]
        public string SerfinsaPaymentAuditNo { get; set; }

        [Required(ErrorMessage = "Serfinsa Payment Time Message Type is required")]
        [MaxLength(100)]
        public string SerfinsaPaymentTimeMessageType { get; set; }

        [MaxLength(100)] public string? SerfinsaPaymentTimeAuthorize { get; set; }

        [Required(ErrorMessage = "Serfinsa Payment Time Answer is required")]
        [MaxLength(100)]
        public string SerfinsaPaymentTimeAnswer { get; set; }

        [Required(ErrorMessage = "Serfinsa Payment Time Type is required")]
        [MaxLength(100)]
        public string SerfinsaPaymentTimeType { get; set; }

        [Required(ErrorMessage = "Created At is required")]
        public DateTime CreatedAt { get; set; }

        [Required(ErrorMessage = "Created By is required")]
        public Guid CreatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public Guid? UpdatedBy { get; set; }

        public bool? IsDeleted { get; set; }

        [Required(ErrorMessage = "Tenant Id is required")]
        public Guid TenantId { get; set; }

        public CustomerDto Customer { get; set; }

        [Required(ErrorMessage = "Customer is required")]
        public Guid CustomerId { get; set; }

        public DiscountCodeDto DiscountCode { get; set; }

        [Required(ErrorMessage = "Discount Code is required")]
        public Guid DiscountCodeId { get; set; }

        public PrepaidPackageDto PrepaidPackage { get; set; }

        [Required(ErrorMessage = "Prepaid Package is required")]
        public Guid PrepaidPackageId { get; set; }

        public List<CustomerPaymentDto> CustomerPayments { get; set; } = new();
    }
}