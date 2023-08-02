using System;
using System.Collections.Generic;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.BusinessUnitCategory
{
    public class ListBusinessUnitCategoryResponse : BaseResponse
    {
        public ListBusinessUnitCategoryResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public ListBusinessUnitCategoryResponse()
        {
        }

        public List<BusinessUnitCategoryDto> BusinessUnitCategories { get; set; } = new();

        public int Count { get; set; }
    }
}