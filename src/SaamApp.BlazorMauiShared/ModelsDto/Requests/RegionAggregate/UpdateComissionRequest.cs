using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.Comission
{
    public class UpdateComissionRequest : BaseRequest
    {
        public Guid ComissionId { get; set; }
        public Guid RegionAreaAdvisorCategoryId { get; set; }
        public decimal ComissionPercentage { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid? UpdatedBy { get; set; }
        public bool? IsDeleted { get; set; }
        public Guid TenantId { get; set; }
        public bool IsDefault { get; set; }

        public static UpdateComissionRequest FromDto(ComissionDto comissionDto)
        {
            return new UpdateComissionRequest
            {
                ComissionId = comissionDto.ComissionId,
                RegionAreaAdvisorCategoryId = comissionDto.RegionAreaAdvisorCategoryId,
                ComissionPercentage = comissionDto.ComissionPercentage,
                CreatedAt = comissionDto.CreatedAt,
                CreatedBy = comissionDto.CreatedBy,
                UpdatedAt = comissionDto.UpdatedAt,
                UpdatedBy = comissionDto.UpdatedBy,
                IsDeleted = comissionDto.IsDeleted,
                TenantId = comissionDto.TenantId,
                IsDefault = comissionDto.IsDefault
            };
        }
    }
}