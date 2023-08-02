using System;

namespace SaamApp.BlazorMauiShared.Models.Area
{
    public class DeleteAreaRequest : BaseRequest
    {
        public Guid AreaId { get; set; }
    }
}