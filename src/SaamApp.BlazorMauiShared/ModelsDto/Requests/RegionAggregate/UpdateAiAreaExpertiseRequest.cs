using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AiAreaExpertise
{
    public class UpdateAiAreaExpertiseRequest : BaseRequest
    {
        public int RowId { get; set; }
        public Guid RegionAreaAdvisorCategoryId { get; set; }
        public Guid ModelId { get; set; }
        public Guid TenantId { get; set; }

        public static UpdateAiAreaExpertiseRequest FromDto(AiAreaExpertiseDto aiAreaExpertiseDto)
        {
            return new UpdateAiAreaExpertiseRequest
            {
                RowId = aiAreaExpertiseDto.RowId,
                RegionAreaAdvisorCategoryId = aiAreaExpertiseDto.RegionAreaAdvisorCategoryId,
                ModelId = aiAreaExpertiseDto.ModelId,
                TenantId = aiAreaExpertiseDto.TenantId
            };
        }
    }
}