using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.Area
{
    public class UpdateAreaRequest : BaseRequest
    {
        public Guid AreaId { get; set; }
        public string AreaName { get; set; }
        public string AreaDescription { get; set; }
        public string AreaColor { get; set; }
        public string AreaImage { get; set; }
        public bool AreaStage { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid? UpdatedBy { get; set; }
        public bool? IsDeleted { get; set; }
        public Guid TenantId { get; set; }

        public static UpdateAreaRequest FromDto(AreaDto areaDto)
        {
            return new UpdateAreaRequest
            {
                AreaId = areaDto.AreaId,
                AreaName = areaDto.AreaName,
                AreaDescription = areaDto.AreaDescription,
                AreaColor = areaDto.AreaColor,
                AreaImage = areaDto.AreaImage,
                AreaStage = areaDto.AreaStage,
                CreatedAt = areaDto.CreatedAt,
                CreatedBy = areaDto.CreatedBy,
                UpdatedAt = areaDto.UpdatedAt,
                UpdatedBy = areaDto.UpdatedBy,
                IsDeleted = areaDto.IsDeleted,
                TenantId = areaDto.TenantId
            };
        }
    }
}