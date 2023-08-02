using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class CustomerReviewDeletedEvent : BaseDomainEvent
    {
        public CustomerReviewDeletedEvent(CustomerReview customerReview, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "CustomerReview";
            Content = JsonConvert.SerializeObject(customerReview, JsonSerializerSettingsSingleton.Instance);
            EventType = "CustomerReviewDeleted";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}