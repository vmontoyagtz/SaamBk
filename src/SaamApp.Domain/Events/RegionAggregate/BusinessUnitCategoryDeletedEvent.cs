using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class BusinessUnitCategoryDeletedEvent : BaseDomainEvent
    {
        public BusinessUnitCategoryDeletedEvent(BusinessUnitCategory businessUnitCategory, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "BusinessUnitCategory";
            Content = JsonConvert.SerializeObject(businessUnitCategory, JsonSerializerSettingsSingleton.Instance);
            EventType = "BusinessUnitCategoryDeleted";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}