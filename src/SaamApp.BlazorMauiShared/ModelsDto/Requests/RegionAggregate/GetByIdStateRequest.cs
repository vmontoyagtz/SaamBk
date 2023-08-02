using System;

namespace SaamApp.BlazorMauiShared.Models.State
{
    public class GetByIdStateRequest : BaseRequest
    {
        public Guid StateId { get; set; }
    }
}