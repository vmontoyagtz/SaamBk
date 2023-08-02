using System;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;

namespace SaamApp.Domain.ModelsDto
{
    public class CustomerPaymentDto
    {
        public CustomerPaymentDto() { } // AutoMapper required

        public CustomerPaymentDto(Guid paymentMethodId, Guid serfinsaPaymentId, Guid tenantId)
        {
            PaymentMethodId = Guard.Against.NullOrEmpty(paymentMethodId, nameof(paymentMethodId));
            SerfinsaPaymentId = Guard.Against.NullOrEmpty(serfinsaPaymentId, nameof(serfinsaPaymentId));
            TenantId = Guard.Against.NullOrEmpty(tenantId, nameof(tenantId));
        }

        public int RowId { get; set; }

        [Required(ErrorMessage = "Tenant Id is required")]
        public Guid TenantId { get; set; }

        public PaymentMethodDto PaymentMethod { get; set; }

        [Required(ErrorMessage = "Payment Method is required")]
        public Guid PaymentMethodId { get; set; }

        public SerfinsaPaymentDto SerfinsaPayment { get; set; }

        [Required(ErrorMessage = "Serfinsa Payment is required")]
        public Guid SerfinsaPaymentId { get; set; }
    }
}