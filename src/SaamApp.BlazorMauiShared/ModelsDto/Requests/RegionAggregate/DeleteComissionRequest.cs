using System;

namespace SaamApp.BlazorMauiShared.Models.Comission
{
    public class DeleteComissionRequest : BaseRequest
    {
        public Guid ComissionId { get; set; }
    }
}