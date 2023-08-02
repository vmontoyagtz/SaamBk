using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.TaxpayerType
{
    public class CreateTaxpayerTypeResponse : BaseResponse
    {
        public CreateTaxpayerTypeResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public CreateTaxpayerTypeResponse()
        {
        }

        public TaxpayerTypeDto TaxpayerType { get; set; } = new();
    }
}