using System;

namespace SaamApp.BlazorMauiShared.Models.AdvisorEmailAddress
{
    public class GetByRelsIdsAdvisorEmailAddressRequest : BaseRequest
    {
        public Guid AdvisorId { get; set; }
        public Guid EmailAddressId { get; set; }
    }
}