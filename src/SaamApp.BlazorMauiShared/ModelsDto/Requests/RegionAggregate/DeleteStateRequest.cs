using System;

namespace SaamApp.BlazorMauiShared.Models.State
{
    public class DeleteStateRequest : BaseRequest
    {
        public Guid StateId { get; set; }
    }
}