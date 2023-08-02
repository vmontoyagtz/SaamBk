using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class AdvisorBankTransferInfoUpdatedEvent : BaseDomainEvent
    {
        public AdvisorBankTransferInfoUpdatedEvent(AdvisorBankTransferInfo advisorBankTransferInfo, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "AdvisorBankTransferInfo";
            Content = JsonConvert.SerializeObject(advisorBankTransferInfo, JsonSerializerSettingsSingleton.Instance);
            EventType = "AdvisorBankTransferInfoUpdated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}