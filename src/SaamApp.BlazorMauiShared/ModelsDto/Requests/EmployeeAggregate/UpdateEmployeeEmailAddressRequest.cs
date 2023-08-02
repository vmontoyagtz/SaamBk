using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.EmployeeEmailAddress
{
    public class UpdateEmployeeEmailAddressRequest : BaseRequest
    {
        public int RowId { get; set; }
        public Guid EmailAddressId { get; set; }
        public Guid EmailAddressTypeId { get; set; }
        public Guid EmployeeId { get; set; }

        public static UpdateEmployeeEmailAddressRequest FromDto(EmployeeEmailAddressDto employeeEmailAddressDto)
        {
            return new UpdateEmployeeEmailAddressRequest
            {
                RowId = employeeEmailAddressDto.RowId,
                EmailAddressId = employeeEmailAddressDto.EmailAddressId,
                EmailAddressTypeId = employeeEmailAddressDto.EmailAddressTypeId,
                EmployeeId = employeeEmailAddressDto.EmployeeId
            };
        }
    }
}