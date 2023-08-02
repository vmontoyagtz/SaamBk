using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.EmployeePhoneNumber
{
    public class UpdateEmployeePhoneNumberRequest : BaseRequest
    {
        public int RowId { get; set; }
        public Guid EmployeeId { get; set; }
        public Guid PhoneNumberId { get; set; }
        public Guid PhoneNumberTypeId { get; set; }

        public static UpdateEmployeePhoneNumberRequest FromDto(EmployeePhoneNumberDto employeePhoneNumberDto)
        {
            return new UpdateEmployeePhoneNumberRequest
            {
                RowId = employeePhoneNumberDto.RowId,
                EmployeeId = employeePhoneNumberDto.EmployeeId,
                PhoneNumberId = employeePhoneNumberDto.PhoneNumberId,
                PhoneNumberTypeId = employeePhoneNumberDto.PhoneNumberTypeId
            };
        }
    }
}