using System;

namespace SaamApp.BlazorMauiShared.Models.BusinessUnitPhoneNumber
{
    public class GetByRelsIdsBusinessUnitPhoneNumberRequest : BaseRequest
    {
        public Guid BusinessUnitId { get; set; }
        public Guid PhoneNumberId { get; set; }
    }
}