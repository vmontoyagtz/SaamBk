using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.BusinessUnitCategory
{
    public class UpdateBusinessUnitCategoryResponse : BaseResponse
    {
        public UpdateBusinessUnitCategoryResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public UpdateBusinessUnitCategoryResponse()
        {
        }

        public BusinessUnitCategoryDto BusinessUnitCategory { get; set; } = new();
    }
}