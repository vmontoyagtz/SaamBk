using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.Comission
{
    public class CreateComissionResponse : BaseResponse
    {
        public CreateComissionResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public CreateComissionResponse()
        {
        }

        public ComissionDto Comission { get; set; } = new();
    }
}