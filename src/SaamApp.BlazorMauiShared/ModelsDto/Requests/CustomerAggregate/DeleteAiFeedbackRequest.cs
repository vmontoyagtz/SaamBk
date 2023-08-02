using System;

namespace SaamApp.BlazorMauiShared.Models.AiFeedback
{
    public class DeleteAiFeedbackRequest : BaseRequest
    {
        public Guid AiFeedbackId { get; set; }
    }
}