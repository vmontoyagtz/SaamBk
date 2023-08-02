using System;

namespace SaamApp.BlazorMauiShared.Models.Gender
{
    public class GetByIdGenderRequest : BaseRequest
    {
        public Guid GenderId { get; set; }
    }
}