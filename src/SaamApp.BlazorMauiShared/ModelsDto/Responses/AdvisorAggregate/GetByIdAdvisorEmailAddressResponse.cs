using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AdvisorEmailAddress
{
    public class GetByIdAdvisorEmailAddressResponse : BaseResponse
    {
        public GetByIdAdvisorEmailAddressResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public GetByIdAdvisorEmailAddressResponse()
        {
        }

        public AdvisorEmailAddressDto AdvisorEmailAddress { get; set; } = new();
    }
}