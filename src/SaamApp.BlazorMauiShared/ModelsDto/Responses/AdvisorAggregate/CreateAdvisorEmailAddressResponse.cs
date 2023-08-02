using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AdvisorEmailAddress
{
    public class CreateAdvisorEmailAddressResponse : BaseResponse
    {
        public CreateAdvisorEmailAddressResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public CreateAdvisorEmailAddressResponse()
        {
        }

        public AdvisorEmailAddressDto AdvisorEmailAddress { get; set; } = new();
    }
}