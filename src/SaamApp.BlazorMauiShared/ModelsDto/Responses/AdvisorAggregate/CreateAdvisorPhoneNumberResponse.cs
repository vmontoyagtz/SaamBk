using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AdvisorPhoneNumber
{
    public class CreateAdvisorPhoneNumberResponse : BaseResponse
    {
        public CreateAdvisorPhoneNumberResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public CreateAdvisorPhoneNumberResponse()
        {
        }

        public AdvisorPhoneNumberDto AdvisorPhoneNumber { get; set; } = new();
    }
}