using System;

namespace SaamApp.BlazorMauiShared.Models.CustomerFeedback
{
    public class CreateCustomerFeedbackRequest : BaseRequest
    {
        public Guid CustomerId { get; set; }
        public DateTime FeedbackDate { get; set; }
        public string FeedbackContent { get; set; }
    }
}