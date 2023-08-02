using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.Comission
{
    public class UpdateComissionResponse : BaseResponse
    {
        public UpdateComissionResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public UpdateComissionResponse()
        {
        }

        public ComissionDto Comission { get; set; } = new();
    }
}