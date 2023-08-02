using System;
using System.Collections.Generic;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.Gender
{
    public class ListGenderResponse : BaseResponse
    {
        public ListGenderResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public ListGenderResponse()
        {
        }

        public List<GenderDto> Genders { get; set; } = new();

        public int Count { get; set; }
    }
}