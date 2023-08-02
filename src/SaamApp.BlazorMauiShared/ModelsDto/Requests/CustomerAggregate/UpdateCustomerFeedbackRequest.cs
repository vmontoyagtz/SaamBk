using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.CustomerFeedback
{
    public class UpdateCustomerFeedbackRequest : BaseRequest
    {
        public Guid FeedbackId { get; set; }
        public Guid CustomerId { get; set; }
        public DateTime FeedbackDate { get; set; }
        public string FeedbackContent { get; set; }

        public static UpdateCustomerFeedbackRequest FromDto(CustomerFeedbackDto customerFeedbackDto)
        {
            return new UpdateCustomerFeedbackRequest
            {
                FeedbackId = customerFeedbackDto.FeedbackId,
                CustomerId = customerFeedbackDto.CustomerId,
                FeedbackDate = customerFeedbackDto.FeedbackDate,
                FeedbackContent = customerFeedbackDto.FeedbackContent
            };
        }
    }
}