using System;

namespace SaamApp.BlazorMauiShared.Models.BusinessUnitType
{
    public class GetByIdBusinessUnitTypeRequest : BaseRequest
    {
        public Guid BusinessUnitTypeId { get; set; }
    }
}