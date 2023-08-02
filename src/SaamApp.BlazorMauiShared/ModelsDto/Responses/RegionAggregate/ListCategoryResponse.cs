using System;
using System.Collections.Generic;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.Category
{
    public class ListCategoryResponse : BaseResponse
    {
        public ListCategoryResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public ListCategoryResponse()
        {
        }

        public List<CategoryDto> Categories { get; set; } = new();

        public int Count { get; set; }
    }
}