using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AdvisorAddress
{
    public class UpdateAdvisorAddressResponse : BaseResponse
    {
        public UpdateAdvisorAddressResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public UpdateAdvisorAddressResponse()
        {
        }

        public AdvisorAddressDto AdvisorAddress { get; set; } = new();
    }
}