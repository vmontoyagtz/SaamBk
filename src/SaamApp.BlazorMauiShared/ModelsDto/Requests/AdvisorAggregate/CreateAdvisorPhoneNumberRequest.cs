using System;

namespace SaamApp.BlazorMauiShared.Models.AdvisorPhoneNumber
{
    public class CreateAdvisorPhoneNumberRequest : BaseRequest
    {
        public Guid AdvisorId { get; set; }
        public Guid PhoneNumberId { get; set; }
        public Guid PhoneNumberTypeId { get; set; }
    }
}