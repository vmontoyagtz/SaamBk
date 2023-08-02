using System;

namespace SaamApp.BlazorMauiShared.Models.TaxInformation
{
    public class GetByIdTaxInformationRequest : BaseRequest
    {
        public Guid TaxInformationId { get; set; }
    }
}