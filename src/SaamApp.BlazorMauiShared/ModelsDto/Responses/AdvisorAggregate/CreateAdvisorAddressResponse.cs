using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AdvisorAddress
{
    public class CreateAdvisorAddressResponse : BaseResponse
    {
        public CreateAdvisorAddressResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public CreateAdvisorAddressResponse()
        {
        }

        public AdvisorAddressDto AdvisorAddress { get; set; } = new();
    }
}