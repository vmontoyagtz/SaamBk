using System;
using System.Collections.Generic;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.BusinessUnit
{
    public class ListBusinessUnitResponse : BaseResponse
    {
        public ListBusinessUnitResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public ListBusinessUnitResponse()
        {
        }

        public List<BusinessUnitDto> BusinessUnits { get; set; } = new();

        public int Count { get; set; }
    }
}