using System;
using System.Collections.Generic;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.BusinessUnitType
{
    public class ListBusinessUnitTypeResponse : BaseResponse
    {
        public ListBusinessUnitTypeResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public ListBusinessUnitTypeResponse()
        {
        }

        public List<BusinessUnitTypeDto> BusinessUnitTypes { get; set; } = new();

        public int Count { get; set; }
    }
}