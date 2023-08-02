using System;

namespace SaamApp.BlazorMauiShared.Models.EmployeePhoneNumber
{
    public class GetByRelsIdsEmployeePhoneNumberRequest : BaseRequest
    {
        public Guid EmployeeId { get; set; }
        public Guid PhoneNumberId { get; set; }
    }
}