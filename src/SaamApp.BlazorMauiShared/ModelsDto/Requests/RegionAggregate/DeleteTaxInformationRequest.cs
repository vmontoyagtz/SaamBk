using System;

namespace SaamApp.BlazorMauiShared.Models.TaxInformation
{
    public class DeleteTaxInformationRequest : BaseRequest
    {
        public Guid TaxInformationId { get; set; }
    }
}