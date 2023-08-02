using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AdvisorPhoneNumber
{
    public class GetByIdAdvisorPhoneNumberResponse : BaseResponse
    {
        public GetByIdAdvisorPhoneNumberResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public GetByIdAdvisorPhoneNumberResponse()
        {
        }

        public AdvisorPhoneNumberDto AdvisorPhoneNumber { get; set; } = new();
    }
}