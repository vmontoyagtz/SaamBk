using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.TaxpayerType
{
    public class GetByIdTaxpayerTypeResponse : BaseResponse
    {
        public GetByIdTaxpayerTypeResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public GetByIdTaxpayerTypeResponse()
        {
        }

        public TaxpayerTypeDto TaxpayerType { get; set; } = new();
    }
}