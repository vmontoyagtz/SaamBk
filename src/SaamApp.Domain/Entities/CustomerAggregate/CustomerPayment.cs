using System;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;
using SaamApp.Domain.Events;
using SaamAppLib.SharedKernel;
using SaamAppLib.SharedKernel.Interfaces;

namespace SaamApp.Domain.Entities
{
    public class CustomerPayment : BaseEntityEv<int>, IAggregateRoot
    {
        private CustomerPayment() { } // EF required

        //[SetsRequiredMembers]
        public CustomerPayment(Guid paymentMethodId, Guid serfinsaPaymentId, Guid tenantId)
        {
            PaymentMethodId = Guard.Against.NullOrEmpty(paymentMethodId, nameof(paymentMethodId));
            SerfinsaPaymentId = Guard.Against.NullOrEmpty(serfinsaPaymentId, nameof(serfinsaPaymentId));
            TenantId = Guard.Against.NullOrEmpty(tenantId, nameof(tenantId));
        }

        [Key] public int RowId { get; private set; }

        public Guid TenantId { get; private set; }

        public virtual PaymentMethod PaymentMethod { get; private set; }

        public Guid PaymentMethodId { get; private set; }

        public virtual SerfinsaPayment SerfinsaPayment { get; private set; }

        public Guid SerfinsaPaymentId { get; private set; }


        public void UpdatePaymentMethodForCustomerPayment(Guid newPaymentMethodId)
        {
            Guard.Against.NullOrEmpty(newPaymentMethodId, nameof(newPaymentMethodId));
            if (newPaymentMethodId == PaymentMethodId)
            {
                return;
            }

            PaymentMethodId = newPaymentMethodId;
            var customerPaymentUpdatedEvent = new CustomerPaymentUpdatedEvent(this, "Mongo-History");
            Events.Add(customerPaymentUpdatedEvent);
        }


        public void UpdateSerfinsaPaymentForCustomerPayment(Guid newSerfinsaPaymentId)
        {
            Guard.Against.NullOrEmpty(newSerfinsaPaymentId, nameof(newSerfinsaPaymentId));
            if (newSerfinsaPaymentId == SerfinsaPaymentId)
            {
                return;
            }

            SerfinsaPaymentId = newSerfinsaPaymentId;
            var customerPaymentUpdatedEvent = new CustomerPaymentUpdatedEvent(this, "Mongo-History");
            Events.Add(customerPaymentUpdatedEvent);
        }
    }
}