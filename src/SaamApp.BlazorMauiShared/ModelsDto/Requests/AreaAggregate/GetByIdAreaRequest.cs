using System;

namespace SaamApp.BlazorMauiShared.Models.Area
{
    public class GetByIdAreaRequest : BaseRequest
    {
        public Guid AreaId { get; set; }
    }
}