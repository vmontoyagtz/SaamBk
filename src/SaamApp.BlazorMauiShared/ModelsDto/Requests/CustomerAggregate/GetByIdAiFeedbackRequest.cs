using System;

namespace SaamApp.BlazorMauiShared.Models.AiFeedback
{
    public class GetByIdAiFeedbackRequest : BaseRequest
    {
        public Guid AiFeedbackId { get; set; }
    }
}