using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AdvisorEmailAddress
{
    public class UpdateAdvisorEmailAddressResponse : BaseResponse
    {
        public UpdateAdvisorEmailAddressResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public UpdateAdvisorEmailAddressResponse()
        {
        }

        public AdvisorEmailAddressDto AdvisorEmailAddress { get; set; } = new();
    }
}