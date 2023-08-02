using System;

namespace SaamApp.BlazorMauiShared.Models.AppConfigParam
{
    public class DeleteAppConfigParamResponse : BaseResponse
    {
        public DeleteAppConfigParamResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public DeleteAppConfigParamResponse()
        {
        }
    }
}