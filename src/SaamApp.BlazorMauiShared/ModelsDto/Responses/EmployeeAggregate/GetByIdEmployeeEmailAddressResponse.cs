using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.EmployeeEmailAddress
{
    public class GetByIdEmployeeEmailAddressResponse : BaseResponse
    {
        public GetByIdEmployeeEmailAddressResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public GetByIdEmployeeEmailAddressResponse()
        {
        }

        public EmployeeEmailAddressDto EmployeeEmailAddress { get; set; } = new();
    }
}