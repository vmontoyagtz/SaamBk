using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.EmployeeEmailAddress
{
    public class CreateEmployeeEmailAddressResponse : BaseResponse
    {
        public CreateEmployeeEmailAddressResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public CreateEmployeeEmailAddressResponse()
        {
        }

        public EmployeeEmailAddressDto EmployeeEmailAddress { get; set; } = new();
    }
}