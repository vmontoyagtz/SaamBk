using System;
using System.Collections.Generic;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.CustomerFeedback
{
    public class ListCustomerFeedbackResponse : BaseResponse
    {
        public ListCustomerFeedbackResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public ListCustomerFeedbackResponse()
        {
        }

        public List<CustomerFeedbackDto> CustomerFeedbacks { get; set; } = new();

        public int Count { get; set; }
    }
}