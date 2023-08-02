using System;

namespace SaamApp.BlazorMauiShared.Models.AdvisorPhoneNumber
{
    public class GetByRelsIdsAdvisorPhoneNumberRequest : BaseRequest
    {
        public Guid AdvisorId { get; set; }
        public Guid PhoneNumberId { get; set; }
    }
}