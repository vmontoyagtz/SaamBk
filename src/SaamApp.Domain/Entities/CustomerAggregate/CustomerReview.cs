using System;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;
using SaamApp.Domain.Events;
using SaamAppLib.SharedKernel;
using SaamAppLib.SharedKernel.Interfaces;

namespace SaamApp.Domain.Entities
{
    public class CustomerReview : BaseEntityEv<Guid>, IAggregateRoot
    {
        private CustomerReview() { } // EF required

        //[SetsRequiredMembers]
        public CustomerReview(Guid customerReviewId, Guid advisorId, Guid customerId, int rating, string? reviewText,
            DateTime createdAt, Guid createdBy, DateTime? updatedAt, Guid? updatedBy, bool? isDeleted, Guid tenantId)
        {
            CustomerReviewId = Guard.Against.NullOrEmpty(customerReviewId, nameof(customerReviewId));
            AdvisorId = Guard.Against.NullOrEmpty(advisorId, nameof(advisorId));
            CustomerId = Guard.Against.NullOrEmpty(customerId, nameof(customerId));
            Rating = Guard.Against.NegativeOrZero(rating, nameof(rating));
            ReviewText = reviewText;
            CreatedAt = Guard.Against.OutOfSQLDateRange(createdAt, nameof(createdAt));
            CreatedBy = Guard.Against.NullOrEmpty(createdBy, nameof(createdBy));
            UpdatedAt = updatedAt;
            UpdatedBy = updatedBy;
            IsDeleted = isDeleted;
            TenantId = Guard.Against.NullOrEmpty(tenantId, nameof(tenantId));
        }

        [Key] public Guid CustomerReviewId { get; private set; }

        public int Rating { get; private set; }

        public string? ReviewText { get; private set; }

        public DateTime CreatedAt { get; private set; }

        public Guid CreatedBy { get; private set; }

        public DateTime? UpdatedAt { get; private set; }

        public Guid? UpdatedBy { get; private set; }

        public bool? IsDeleted { get; private set; }

        public Guid TenantId { get; private set; }
        public virtual Advisor Advisor { get; private set; }

        public Guid AdvisorId { get; private set; }

        public virtual Customer Customer { get; private set; }

        public Guid CustomerId { get; private set; }


        public void UpdateAdvisorForCustomerReview(Guid newAdvisorId)
        {
            Guard.Against.NullOrEmpty(newAdvisorId, nameof(newAdvisorId));
            if (newAdvisorId == AdvisorId)
            {
                return;
            }

            AdvisorId = newAdvisorId;
            var customerReviewUpdatedEvent = new CustomerReviewUpdatedEvent(this, "Mongo-History");
            Events.Add(customerReviewUpdatedEvent);
        }


        public void UpdateCustomerForCustomerReview(Guid newCustomerId)
        {
            Guard.Against.NullOrEmpty(newCustomerId, nameof(newCustomerId));
            if (newCustomerId == CustomerId)
            {
                return;
            }

            CustomerId = newCustomerId;
            var customerReviewUpdatedEvent = new CustomerReviewUpdatedEvent(this, "Mongo-History");
            Events.Add(customerReviewUpdatedEvent);
        }

        public void SetReviewText(string reviewText)
        {
            ReviewText = reviewText;
        }
    }
}