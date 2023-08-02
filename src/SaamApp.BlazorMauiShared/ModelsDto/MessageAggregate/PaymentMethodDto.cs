using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;

namespace SaamApp.Domain.ModelsDto
{
    public class PaymentMethodDto
    {
        public PaymentMethodDto() { } // AutoMapper required

        public PaymentMethodDto(Guid paymentMethodId, string paymentFrequencyCode, string paymentMethodName,
            string paymentMethodDescription, Guid tenantId)
        {
            PaymentMethodId = Guard.Against.NullOrEmpty(paymentMethodId, nameof(paymentMethodId));
            PaymentFrequencyCode = Guard.Against.NullOrWhiteSpace(paymentFrequencyCode, nameof(paymentFrequencyCode));
            PaymentMethodName = Guard.Against.NullOrWhiteSpace(paymentMethodName, nameof(paymentMethodName));
            PaymentMethodDescription =
                Guard.Against.NullOrWhiteSpace(paymentMethodDescription, nameof(paymentMethodDescription));
            TenantId = Guard.Against.NullOrEmpty(tenantId, nameof(tenantId));
        }

        public Guid PaymentMethodId { get; set; }

        [Required(ErrorMessage = "Payment Frequency Code is required")]
        [MaxLength(100)]
        public string PaymentFrequencyCode { get; set; }

        [Required(ErrorMessage = "Payment Method Name is required")]
        [MaxLength(100)]
        public string PaymentMethodName { get; set; }

        [Required(ErrorMessage = "Payment Method Description is required")]
        [MaxLength(100)]
        public string PaymentMethodDescription { get; set; }

        [Required(ErrorMessage = "Tenant Id is required")]
        public Guid TenantId { get; set; }

        public List<AdvisorPaymentDto> AdvisorPayments { get; set; } = new();
        public List<CustomerPaymentDto> CustomerPayments { get; set; } = new();
    }
}