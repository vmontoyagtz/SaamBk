using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.BusinessUnitCategory
{
    public class UpdateBusinessUnitCategoryRequest : BaseRequest
    {
        public int RowId { get; set; }
        public Guid BusinessUnitId { get; set; }
        public Guid RegionAreaAdvisorCategoryId { get; set; }

        public static UpdateBusinessUnitCategoryRequest FromDto(BusinessUnitCategoryDto businessUnitCategoryDto)
        {
            return new UpdateBusinessUnitCategoryRequest
            {
                RowId = businessUnitCategoryDto.RowId,
                BusinessUnitId = businessUnitCategoryDto.BusinessUnitId,
                RegionAreaAdvisorCategoryId = businessUnitCategoryDto.RegionAreaAdvisorCategoryId
            };
        }
    }
}