using System;

namespace SaamApp.BlazorMauiShared.Models.BusinessUnitEmailAddress
{
    public class GetByRelsIdsBusinessUnitEmailAddressRequest : BaseRequest
    {
        public Guid BusinessUnitId { get; set; }
        public Guid EmailAddressId { get; set; }
    }
}