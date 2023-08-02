using System;

namespace SaamApp.BlazorMauiShared.Models.TaxpayerType
{
    public class CreateTaxpayerTypeRequest : BaseRequest
    {
        public string TaxpayerTypeName { get; set; }
        public Guid TenantId { get; set; }
    }
}