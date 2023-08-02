using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class CustomerReviewUpdatedEvent : BaseDomainEvent
    {
        public CustomerReviewUpdatedEvent(CustomerReview customerReview, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "CustomerReview";
            Content = JsonConvert.SerializeObject(customerReview, JsonSerializerSettingsSingleton.Instance);
            EventType = "CustomerReviewUpdated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}