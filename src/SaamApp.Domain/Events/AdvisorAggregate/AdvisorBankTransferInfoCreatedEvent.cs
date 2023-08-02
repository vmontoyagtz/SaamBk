using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class AdvisorBankTransferInfoCreatedEvent : BaseDomainEvent
    {
        public AdvisorBankTransferInfoCreatedEvent(AdvisorBankTransferInfo advisorBankTransferInfo, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "AdvisorBankTransferInfo";
            Content = JsonConvert.SerializeObject(advisorBankTransferInfo, JsonSerializerSettingsSingleton.Instance);
            EventType = "AdvisorBankTransferInfoCreated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}