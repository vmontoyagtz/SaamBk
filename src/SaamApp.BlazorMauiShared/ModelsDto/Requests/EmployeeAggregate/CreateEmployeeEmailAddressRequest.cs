using System;

namespace SaamApp.BlazorMauiShared.Models.EmployeeEmailAddress
{
    public class CreateEmployeeEmailAddressRequest : BaseRequest
    {
        public Guid EmailAddressId { get; set; }
        public Guid EmailAddressTypeId { get; set; }
        public Guid EmployeeId { get; set; }
    }
}