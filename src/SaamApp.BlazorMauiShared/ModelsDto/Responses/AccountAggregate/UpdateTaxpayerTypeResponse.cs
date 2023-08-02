using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.TaxpayerType
{
    public class UpdateTaxpayerTypeResponse : BaseResponse
    {
        public UpdateTaxpayerTypeResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public UpdateTaxpayerTypeResponse()
        {
        }

        public TaxpayerTypeDto TaxpayerType { get; set; } = new();
    }
}