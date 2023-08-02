using System;

namespace SaamApp.BlazorMauiShared.Models.EmployeeAddress
{
    public class GetByRelsIdsEmployeeAddressRequest : BaseRequest
    {
        public Guid AddressId { get; set; }
        public Guid EmployeeId { get; set; }
    }
}