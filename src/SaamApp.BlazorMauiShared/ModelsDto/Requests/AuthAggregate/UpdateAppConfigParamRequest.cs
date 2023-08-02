using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AppConfigParam
{
    public class UpdateAppConfigParamRequest : BaseRequest
    {
        public Guid AppConfigParamId { get; set; }
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

        public static UpdateAppConfigParamRequest FromDto(AppConfigParamDto appConfigParamDto)
        {
            return new UpdateAppConfigParamRequest
            {
                AppConfigParamId = appConfigParamDto.AppConfigParamId,
                AppConfigParamName = appConfigParamDto.AppConfigParamName,
                AppConfigParamValue = appConfigParamDto.AppConfigParamValue,
                AppConfigParamDescription = appConfigParamDto.AppConfigParamDescription,
                CustomerLowBalance = appConfigParamDto.CustomerLowBalance,
                AppConfigSettingsJson = appConfigParamDto.AppConfigSettingsJson,
                CreatedAt = appConfigParamDto.CreatedAt,
                CreatedBy = appConfigParamDto.CreatedBy,
                UpdatedAt = appConfigParamDto.UpdatedAt,
                UpdatedBy = appConfigParamDto.UpdatedBy,
                IsDeleted = appConfigParamDto.IsDeleted,
                TenantId = appConfigParamDto.TenantId
            };
        }
    }
}