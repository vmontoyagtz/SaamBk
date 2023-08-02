using System;
using System.Collections.Generic;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.TaxInformation
{
    public class ListTaxInformationResponse : BaseResponse
    {
        public ListTaxInformationResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public ListTaxInformationResponse()
        {
        }

        public List<TaxInformationDto> TaxInformations { get; set; } = new();

        public int Count { get; set; }
    }
}