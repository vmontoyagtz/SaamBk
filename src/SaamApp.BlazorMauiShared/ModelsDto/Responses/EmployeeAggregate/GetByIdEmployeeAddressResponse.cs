using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.EmployeeAddress
{
    public class GetByIdEmployeeAddressResponse : BaseResponse
    {
        public GetByIdEmployeeAddressResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public GetByIdEmployeeAddressResponse()
        {
        }

        public EmployeeAddressDto EmployeeAddress { get; set; } = new();
    }
}