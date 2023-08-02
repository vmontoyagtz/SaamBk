using System;

namespace SaamApp.BlazorMauiShared.Models.AppConfigParam
{
    public class CreateAppConfigParamRequest : BaseRequest
    {
        public string AppConfigParamName { get; set; }
        public string AppConfigParamValue { get; set; }
        public string AppConfigParamDescription { get; set; }
        public decimal CustomerLowBalance { get; set; }
        public string? AppConfigSettingsJson { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid? UpdatedBy { get; set; }
        public bool? IsDeleted { get; set; }
        public Guid TenantId { get; set; }
    }
}