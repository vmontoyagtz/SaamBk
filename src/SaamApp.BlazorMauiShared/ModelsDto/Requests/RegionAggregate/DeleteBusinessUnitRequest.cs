using System;

namespace SaamApp.BlazorMauiShared.Models.BusinessUnit
{
    public class DeleteBusinessUnitRequest : BaseRequest
    {
        public Guid BusinessUnitId { get; set; }
    }
}