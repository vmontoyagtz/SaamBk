using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.Category
{
    public class UpdateCategoryResponse : BaseResponse
    {
        public UpdateCategoryResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public UpdateCategoryResponse()
        {
        }

        public CategoryDto Category { get; set; } = new();
    }
}