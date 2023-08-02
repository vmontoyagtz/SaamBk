using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AdvisorPhoneNumber
{
    public class UpdateAdvisorPhoneNumberResponse : BaseResponse
    {
        public UpdateAdvisorPhoneNumberResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public UpdateAdvisorPhoneNumberResponse()
        {
        }

        public AdvisorPhoneNumberDto AdvisorPhoneNumber { get; set; } = new();
    }
}