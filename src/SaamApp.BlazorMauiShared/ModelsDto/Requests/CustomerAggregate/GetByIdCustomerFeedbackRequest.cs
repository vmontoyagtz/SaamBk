using System;

namespace SaamApp.BlazorMauiShared.Models.CustomerFeedback
{
    public class GetByIdCustomerFeedbackRequest : BaseRequest
    {
        public Guid FeedbackId { get; set; }
    }
}