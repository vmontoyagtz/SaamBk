using System;

namespace SaamApp.BlazorMauiShared.Models.AdvisorEmailAddress
{
    public class CreateAdvisorEmailAddressRequest : BaseRequest
    {
        public Guid AdvisorId { get; set; }
        public Guid EmailAddressId { get; set; }
        public Guid EmailAddressTypeId { get; set; }
    }
}