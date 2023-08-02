using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class CustomerReviewCreatedEvent : BaseDomainEvent
    {
        public CustomerReviewCreatedEvent(CustomerReview customerReview, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "CustomerReview";
            Content = JsonConvert.SerializeObject(customerReview, JsonSerializerSettingsSingleton.Instance);
            EventType = "CustomerReviewCreated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}