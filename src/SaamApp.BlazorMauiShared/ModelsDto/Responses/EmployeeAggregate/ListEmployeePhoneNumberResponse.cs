using System;
using System.Collections.Generic;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.EmployeePhoneNumber
{
    public class ListEmployeePhoneNumberResponse : BaseResponse
    {
        public ListEmployeePhoneNumberResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public ListEmployeePhoneNumberResponse()
        {
        }

        public List<EmployeePhoneNumberDto> EmployeePhoneNumbers { get; set; } = new();

        public int Count { get; set; }
    }
}