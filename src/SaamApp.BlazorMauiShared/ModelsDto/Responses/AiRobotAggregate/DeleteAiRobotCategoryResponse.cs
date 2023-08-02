using System;

namespace SaamApp.BlazorMauiShared.Models.AiRobotCategory
{
    public class DeleteAiRobotCategoryResponse : BaseResponse
    {
        public DeleteAiRobotCategoryResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public DeleteAiRobotCategoryResponse()
        {
        }
    }
}