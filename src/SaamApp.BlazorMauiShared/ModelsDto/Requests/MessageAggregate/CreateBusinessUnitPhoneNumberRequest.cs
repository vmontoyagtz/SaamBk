using System;

namespace SaamApp.BlazorMauiShared.Models.BusinessUnitPhoneNumber
{
    public class CreateBusinessUnitPhoneNumberRequest : BaseRequest
    {
        public Guid BusinessUnitId { get; set; }
        public Guid PhoneNumberId { get; set; }
        public Guid PhoneNumberTypeId { get; set; }
    }
}