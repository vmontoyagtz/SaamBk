using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.EmployeePhoneNumber
{
    public class CreateEmployeePhoneNumberResponse : BaseResponse
    {
        public CreateEmployeePhoneNumberResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public CreateEmployeePhoneNumberResponse()
        {
        }

        public EmployeePhoneNumberDto EmployeePhoneNumber { get; set; } = new();
    }
}