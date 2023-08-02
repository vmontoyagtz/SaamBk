using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.BusinessUnitCategory
{
    public class CreateBusinessUnitCategoryResponse : BaseResponse
    {
        public CreateBusinessUnitCategoryResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public CreateBusinessUnitCategoryResponse()
        {
        }

        public BusinessUnitCategoryDto BusinessUnitCategory { get; set; } = new();
    }
}