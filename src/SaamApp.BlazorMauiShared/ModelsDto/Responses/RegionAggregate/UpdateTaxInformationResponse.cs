using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.TaxInformation
{
    public class UpdateTaxInformationResponse : BaseResponse
    {
        public UpdateTaxInformationResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public UpdateTaxInformationResponse()
        {
        }

        public TaxInformationDto TaxInformation { get; set; } = new();
    }
}