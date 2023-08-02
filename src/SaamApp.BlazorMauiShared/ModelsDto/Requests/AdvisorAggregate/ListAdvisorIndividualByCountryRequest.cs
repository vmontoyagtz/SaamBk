using System;

namespace SaamApp.BlazorMauiShared.Models.Advisor
{
    public class ListAdvisorIndividualByCountryRequest : BaseRequest
    {
        public Guid CountryId { get; set; }
    }
}