using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Ardalis.GuardClauses;
using SaamApp.Domain.Events;
using SaamAppLib.SharedKernel;
using SaamAppLib.SharedKernel.Interfaces;

namespace SaamApp.Domain.Entities
{
    public class SerfinsaPayment : BaseEntityEv<Guid>, IAggregateRoot
    {
        private readonly List<CustomerPayment> _customerPayments = new();

        private SerfinsaPayment() { } // EF required

        //[SetsRequiredMembers]
        public SerfinsaPayment(Guid serfinsaPaymentId, Guid customerId, Guid discountCodeId, Guid prepaidPackageId,
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

        [Key] public Guid SerfinsaPaymentId { get; private set; }

        public string SerfinsaPaymentAmount { get; private set; }

        public string SerfinsaPaymentTime { get; private set; }

        public string SerfinsaPaymentDate { get; private set; }

        public string SerfinsaPaymentReferenceNumber { get; private set; }

        public string SerfinsaPaymentAuditNo { get; private set; }

        public string SerfinsaPaymentTimeMessageType { get; private set; }

        public string? SerfinsaPaymentTimeAuthorize { get; private set; }

        public string SerfinsaPaymentTimeAnswer { get; private set; }

        public string SerfinsaPaymentTimeType { get; private set; }

        public DateTime CreatedAt { get; private set; }

        public Guid CreatedBy { get; private set; }

        public DateTime? UpdatedAt { get; private set; }

        public Guid? UpdatedBy { get; private set; }

        public bool? IsDeleted { get; private set; }

        public Guid TenantId { get; private set; }

        public virtual Customer Customer { get; private set; }

        public Guid CustomerId { get; private set; }

        public virtual DiscountCode DiscountCode { get; private set; }

        public Guid DiscountCodeId { get; private set; }

        public virtual PrepaidPackage PrepaidPackage { get; private set; }

        public Guid PrepaidPackageId { get; private set; }
        public IEnumerable<CustomerPayment> CustomerPayments => _customerPayments.AsReadOnly();

        public void SetSerfinsaPaymentAmount(string serfinsaPaymentAmount)
        {
            SerfinsaPaymentAmount = Guard.Against.NullOrEmpty(serfinsaPaymentAmount, nameof(serfinsaPaymentAmount));
        }

        public void SetSerfinsaPaymentTime(string serfinsaPaymentTime)
        {
            SerfinsaPaymentTime = Guard.Against.NullOrEmpty(serfinsaPaymentTime, nameof(serfinsaPaymentTime));
        }

        public void SetSerfinsaPaymentDate(string serfinsaPaymentDate)
        {
            SerfinsaPaymentDate = Guard.Against.NullOrEmpty(serfinsaPaymentDate, nameof(serfinsaPaymentDate));
        }

        public void SetSerfinsaPaymentReferenceNumber(string serfinsaPaymentReferenceNumber)
        {
            SerfinsaPaymentReferenceNumber = Guard.Against.NullOrEmpty(serfinsaPaymentReferenceNumber,
                nameof(serfinsaPaymentReferenceNumber));
        }

        public void SetSerfinsaPaymentAuditNo(string serfinsaPaymentAuditNo)
        {
            SerfinsaPaymentAuditNo = Guard.Against.NullOrEmpty(serfinsaPaymentAuditNo, nameof(serfinsaPaymentAuditNo));
        }

        public void SetSerfinsaPaymentTimeMessageType(string serfinsaPaymentTimeMessageType)
        {
            SerfinsaPaymentTimeMessageType = Guard.Against.NullOrEmpty(serfinsaPaymentTimeMessageType,
                nameof(serfinsaPaymentTimeMessageType));
        }

        public void SetSerfinsaPaymentTimeAuthorize(string serfinsaPaymentTimeAuthorize)
        {
            SerfinsaPaymentTimeAuthorize = serfinsaPaymentTimeAuthorize;
        }

        public void SetSerfinsaPaymentTimeAnswer(string serfinsaPaymentTimeAnswer)
        {
            SerfinsaPaymentTimeAnswer =
                Guard.Against.NullOrEmpty(serfinsaPaymentTimeAnswer, nameof(serfinsaPaymentTimeAnswer));
        }

        public void SetSerfinsaPaymentTimeType(string serfinsaPaymentTimeType)
        {
            SerfinsaPaymentTimeType =
                Guard.Against.NullOrEmpty(serfinsaPaymentTimeType, nameof(serfinsaPaymentTimeType));
        }

        public void UpdateCustomerForSerfinsaPayment(Guid newCustomerId)
        {
            Guard.Against.NullOrEmpty(newCustomerId, nameof(newCustomerId));
            if (newCustomerId == CustomerId)
            {
                return;
            }

            CustomerId = newCustomerId;
            var serfinsaPaymentUpdatedEvent = new SerfinsaPaymentUpdatedEvent(this, "Mongo-History");
            Events.Add(serfinsaPaymentUpdatedEvent);
        }


        public void UpdateDiscountCodeForSerfinsaPayment(Guid newDiscountCodeId)
        {
            Guard.Against.NullOrEmpty(newDiscountCodeId, nameof(newDiscountCodeId));
            if (newDiscountCodeId == DiscountCodeId)
            {
                return;
            }

            DiscountCodeId = newDiscountCodeId;
            var serfinsaPaymentUpdatedEvent = new SerfinsaPaymentUpdatedEvent(this, "Mongo-History");
            Events.Add(serfinsaPaymentUpdatedEvent);
        }


        public void UpdatePrepaidPackageForSerfinsaPayment(Guid newPrepaidPackageId)
        {
            Guard.Against.NullOrEmpty(newPrepaidPackageId, nameof(newPrepaidPackageId));
            if (newPrepaidPackageId == PrepaidPackageId)
            {
                return;
            }

            PrepaidPackageId = newPrepaidPackageId;
            var serfinsaPaymentUpdatedEvent = new SerfinsaPaymentUpdatedEvent(this, "Mongo-History");
            Events.Add(serfinsaPaymentUpdatedEvent);
        }


        public void AddNewCustomerPayment(Guid paymentMethodId, Guid serfinsaPaymentId, Guid tenantId)
        {
            Guard.Against.NullOrEmpty(paymentMethodId, nameof(paymentMethodId));
            Guard.Against.NullOrEmpty(serfinsaPaymentId, nameof(serfinsaPaymentId));
            Guard.Against.NullOrEmpty(tenantId, nameof(tenantId));

            var newCustomerPayment = new CustomerPayment(paymentMethodId, serfinsaPaymentId, tenantId);
            Guard.Against.DuplicateCustomerPayment(_customerPayments, newCustomerPayment, nameof(newCustomerPayment));
            _customerPayments.Add(newCustomerPayment);
            var customerPaymentAddedEvent = new CustomerPaymentCreatedEvent(newCustomerPayment, "Mongo-History");
            Events.Add(customerPaymentAddedEvent);
        }

        public void DeleteCustomerPayment(Guid paymentMethodId, Guid serfinsaPaymentId, Guid tenantId)
        {
            Guard.Against.NullOrEmpty(paymentMethodId, nameof(paymentMethodId));
            Guard.Against.NullOrEmpty(serfinsaPaymentId, nameof(serfinsaPaymentId));
            Guard.Against.NullOrEmpty(tenantId, nameof(tenantId));

            var customerPaymentToDelete = _customerPayments
                .Where(cp1 => cp1.PaymentMethodId == paymentMethodId)
                .Where(cp2 => cp2.SerfinsaPaymentId == serfinsaPaymentId)
                .Where(cp3 => cp3.TenantId == tenantId)
                .FirstOrDefault();

            if (customerPaymentToDelete != null)
            {
                _customerPayments.Remove(customerPaymentToDelete);
                var customerPaymentDeletedEvent =
                    new CustomerPaymentDeletedEvent(customerPaymentToDelete, "Mongo-History");
                Events.Add(customerPaymentDeletedEvent);
            }
        }
    }
}