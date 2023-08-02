using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.EmployeePhoneNumber
{
    public class UpdateEmployeePhoneNumberResponse : BaseResponse
    {
        public UpdateEmployeePhoneNumberResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public UpdateEmployeePhoneNumberResponse()
        {
        }

        public EmployeePhoneNumberDto EmployeePhoneNumber { get; set; } = new();
    }
}