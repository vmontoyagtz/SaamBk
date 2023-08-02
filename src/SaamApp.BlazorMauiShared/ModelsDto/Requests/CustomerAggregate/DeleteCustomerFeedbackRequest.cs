using System;

namespace SaamApp.BlazorMauiShared.Models.CustomerFeedback
{
    public class DeleteCustomerFeedbackRequest : BaseRequest
    {
        public Guid FeedbackId { get; set; }
    }
}