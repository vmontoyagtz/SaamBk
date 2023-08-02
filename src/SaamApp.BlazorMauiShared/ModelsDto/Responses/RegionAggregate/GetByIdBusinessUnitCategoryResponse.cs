using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.BusinessUnitCategory
{
    public class GetByIdBusinessUnitCategoryResponse : BaseResponse
    {
        public GetByIdBusinessUnitCategoryResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public GetByIdBusinessUnitCategoryResponse()
        {
        }

        public BusinessUnitCategoryDto BusinessUnitCategory { get; set; } = new();
    }
}