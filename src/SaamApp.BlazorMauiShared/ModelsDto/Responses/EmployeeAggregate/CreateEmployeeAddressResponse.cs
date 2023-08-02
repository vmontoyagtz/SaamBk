using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.EmployeeAddress
{
    public class CreateEmployeeAddressResponse : BaseResponse
    {
        public CreateEmployeeAddressResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public CreateEmployeeAddressResponse()
        {
        }

        public EmployeeAddressDto EmployeeAddress { get; set; } = new();
    }
}