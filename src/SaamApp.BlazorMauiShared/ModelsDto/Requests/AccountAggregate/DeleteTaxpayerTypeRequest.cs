using System;

namespace SaamApp.BlazorMauiShared.Models.TaxpayerType
{
    public class DeleteTaxpayerTypeRequest : BaseRequest
    {
        public Guid TaxpayerTypeId { get; set; }
    }
}