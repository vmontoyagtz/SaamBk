using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AdvisorAddress
{
    public class GetByIdAdvisorAddressResponse : BaseResponse
    {
        public GetByIdAdvisorAddressResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public GetByIdAdvisorAddressResponse()
        {
        }

        public AdvisorAddressDto AdvisorAddress { get; set; } = new();
    }
}