using System;

namespace SaamApp.BlazorMauiShared.Models.EmployeePhoneNumber
{
    public class CreateEmployeePhoneNumberRequest : BaseRequest
    {
        public Guid EmployeeId { get; set; }
        public Guid PhoneNumberId { get; set; }
        public Guid PhoneNumberTypeId { get; set; }
    }
}