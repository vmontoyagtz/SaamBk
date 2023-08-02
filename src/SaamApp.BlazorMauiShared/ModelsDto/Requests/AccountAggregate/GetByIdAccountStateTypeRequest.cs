using System;

namespace SaamApp.BlazorMauiShared.Models.AccountStateType
{
    public class GetByIdAccountStateTypeRequest : BaseRequest
    {
        public Guid AccountStateTypeId { get; set; }
    }
}