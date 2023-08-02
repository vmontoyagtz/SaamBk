using System;

namespace SaamApp.BlazorMauiShared.Models.EmployeeEmailAddress
{
    public class GetByRelsIdsEmployeeEmailAddressRequest : BaseRequest
    {
        public Guid EmailAddressId { get; set; }
        public Guid EmployeeId { get; set; }
    }
}