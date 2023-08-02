using System;

namespace SaamApp.BlazorMauiShared.Models.BusinessUnit
{
    public class GetByIdBusinessUnitRequest : BaseRequest
    {
        public Guid BusinessUnitId { get; set; }
    }
}