using System;
using System.Collections.Generic;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AiFeedback
{
    public class ListAiFeedbackResponse : BaseResponse
    {
        public ListAiFeedbackResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public ListAiFeedbackResponse()
        {
        }

        public List<AiFeedbackDto> AiFeedbacks { get; set; } = new();

        public int Count { get; set; }
    }
}