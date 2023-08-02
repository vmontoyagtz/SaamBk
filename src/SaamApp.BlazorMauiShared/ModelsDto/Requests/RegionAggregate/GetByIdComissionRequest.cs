using System;

namespace SaamApp.BlazorMauiShared.Models.Comission
{
    public class GetByIdComissionRequest : BaseRequest
    {
        public Guid ComissionId { get; set; }
    }
}