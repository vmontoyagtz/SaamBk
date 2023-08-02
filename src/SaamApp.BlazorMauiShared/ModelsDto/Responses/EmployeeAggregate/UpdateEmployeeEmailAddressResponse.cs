using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.EmployeeEmailAddress
{
    public class UpdateEmployeeEmailAddressResponse : BaseResponse
    {
        public UpdateEmployeeEmailAddressResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public UpdateEmployeeEmailAddressResponse()
        {
        }

        public EmployeeEmailAddressDto EmployeeEmailAddress { get; set; } = new();
    }
}