using System;

namespace SaamApp.BlazorMauiShared.Models.BusinessUnitType
{
    public class DeleteBusinessUnitTypeRequest : BaseRequest
    {
        public Guid BusinessUnitTypeId { get; set; }
    }
}