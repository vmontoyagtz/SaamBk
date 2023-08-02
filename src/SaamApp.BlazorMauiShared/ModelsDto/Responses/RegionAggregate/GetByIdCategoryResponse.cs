using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.Category
{
    public class GetByIdCategoryResponse : BaseResponse
    {
        public GetByIdCategoryResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public GetByIdCategoryResponse()
        {
        }

        public CategoryDto Category { get; set; } = new();
    }
}