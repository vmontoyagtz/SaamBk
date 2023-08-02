using System;
using System.Collections.Generic;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.TaxpayerType
{
    public class ListTaxpayerTypeResponse : BaseResponse
    {
        public ListTaxpayerTypeResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public ListTaxpayerTypeResponse()
        {
        }

        public List<TaxpayerTypeDto> TaxpayerTypes { get; set; } = new();

        public int Count { get; set; }
    }
}