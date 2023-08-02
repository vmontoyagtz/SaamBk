using System;

namespace SaamApp.BlazorMauiShared.Models.EmployeeAddress
{
    public class CreateEmployeeAddressRequest : BaseRequest
    {
        public Guid AddressId { get; set; }
        public Guid AddressTypeId { get; set; }
        public Guid EmployeeId { get; set; }
    }
}