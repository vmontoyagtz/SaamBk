using System;

namespace SaamApp.BlazorMauiShared.Models.BusinessUnitEmailAddress
{
    public class CreateBusinessUnitEmailAddressRequest : BaseRequest
    {
        public Guid BusinessUnitId { get; set; }
        public Guid EmailAddressId { get; set; }
        public Guid EmailAddressTypeId { get; set; }
    }
}