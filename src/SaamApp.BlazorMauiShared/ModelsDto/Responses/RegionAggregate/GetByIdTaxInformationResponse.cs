using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.TaxInformation
{
    public class GetByIdTaxInformationResponse : BaseResponse
    {
        public GetByIdTaxInformationResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public GetByIdTaxInformationResponse()
        {
        }

        public TaxInformationDto TaxInformation { get; set; } = new();
    }
}