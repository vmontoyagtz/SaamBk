using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.EmployeeAddress
{
    public class UpdateEmployeeAddressRequest : BaseRequest
    {
        public int RowId { get; set; }
        public Guid AddressId { get; set; }
        public Guid AddressTypeId { get; set; }
        public Guid EmployeeId { get; set; }

        public static UpdateEmployeeAddressRequest FromDto(EmployeeAddressDto employeeAddressDto)
        {
            return new UpdateEmployeeAddressRequest
            {
                RowId = employeeAddressDto.RowId,
                AddressId = employeeAddressDto.AddressId,
                AddressTypeId = employeeAddressDto.AddressTypeId,
                EmployeeId = employeeAddressDto.EmployeeId
            };
        }
    }
}