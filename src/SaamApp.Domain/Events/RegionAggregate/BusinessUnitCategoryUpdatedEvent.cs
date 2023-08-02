using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class BusinessUnitCategoryUpdatedEvent : BaseDomainEvent
    {
        public BusinessUnitCategoryUpdatedEvent(BusinessUnitCategory businessUnitCategory, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "BusinessUnitCategory";
            Content = JsonConvert.SerializeObject(businessUnitCategory, JsonSerializerSettingsSingleton.Instance);
            EventType = "BusinessUnitCategoryUpdated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}