using System;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;
using SaamApp.Domain.Events;
using SaamAppLib.SharedKernel;
using SaamAppLib.SharedKernel.Interfaces;

namespace SaamApp.Domain.Entities
{
    public class CustomerFeedback : BaseEntityEv<Guid>, IAggregateRoot
    {
        private CustomerFeedback() { } // EF required

        //[SetsRequiredMembers]
        public CustomerFeedback(Guid feedbackId, Guid customerId, DateTime feedbackDate, string feedbackContent)
        {
            FeedbackId = Guard.Against.NullOrEmpty(feedbackId, nameof(feedbackId));
            CustomerId = Guard.Against.NullOrEmpty(customerId, nameof(customerId));
            FeedbackDate = Guard.Against.OutOfSQLDateRange(feedbackDate, nameof(feedbackDate));
            FeedbackContent = Guard.Against.NullOrWhiteSpace(feedbackContent, nameof(feedbackContent));
        }

        [Key] public Guid FeedbackId { get; private set; }

        public DateTime FeedbackDate { get; private set; }

        public string FeedbackContent { get; private set; }
        public virtual Customer Customer { get; private set; }

        public Guid CustomerId { get; private set; }


        public void UpdateCustomerForCustomerFeedback(Guid newCustomerId)
        {
            Guard.Against.NullOrEmpty(newCustomerId, nameof(newCustomerId));
            if (newCustomerId == CustomerId)
            {
                return;
            }

            CustomerId = newCustomerId;
            var customerFeedbackUpdatedEvent = new CustomerFeedbackUpdatedEvent(this, "Mongo-History");
            Events.Add(customerFeedbackUpdatedEvent);
        }

        public void SetFeedbackContent(string feedbackContent)
        {
            FeedbackContent = Guard.Against.NullOrEmpty(feedbackContent, nameof(feedbackContent));
        }
    }
}