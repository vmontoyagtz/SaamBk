using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.EmployeePhoneNumber
{
    public class GetByIdEmployeePhoneNumberResponse : BaseResponse
    {
        public GetByIdEmployeePhoneNumberResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public GetByIdEmployeePhoneNumberResponse()
        {
        }

        public EmployeePhoneNumberDto EmployeePhoneNumber { get; set; } = new();
    }
}