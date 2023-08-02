using System;

namespace SaamApp.BlazorMauiShared.Models.Gender
{
    public class DeleteGenderRequest : BaseRequest
    {
        public Guid GenderId { get; set; }
    }
}