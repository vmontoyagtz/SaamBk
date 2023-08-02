using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.EmployeeAddress
{
    public class UpdateEmployeeAddressResponse : BaseResponse
    {
        public UpdateEmployeeAddressResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public UpdateEmployeeAddressResponse()
        {
        }

        public EmployeeAddressDto EmployeeAddress { get; set; } = new();
    }
}