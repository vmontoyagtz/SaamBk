using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.Category
{
    public class CreateCategoryResponse : BaseResponse
    {
        public CreateCategoryResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public CreateCategoryResponse()
        {
        }

        public CategoryDto Category { get; set; } = new();
    }
}