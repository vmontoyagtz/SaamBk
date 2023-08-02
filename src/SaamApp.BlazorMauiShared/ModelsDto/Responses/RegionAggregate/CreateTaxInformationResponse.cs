using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.TaxInformation
{
    public class CreateTaxInformationResponse : BaseResponse
    {
        public CreateTaxInformationResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public CreateTaxInformationResponse()
        {
        }

        public TaxInformationDto TaxInformation { get; set; } = new();
    }
}