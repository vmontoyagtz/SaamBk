using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.Gender
{
    public class CreateGenderResponse : BaseResponse
    {
        public CreateGenderResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public CreateGenderResponse()
        {
        }

        public GenderDto Gender { get; set; } = new();
    }
}