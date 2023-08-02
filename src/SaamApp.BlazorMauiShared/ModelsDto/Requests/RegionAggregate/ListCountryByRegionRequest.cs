using System;

namespace SaamApp.BlazorMauiShared.Models.Country
{
    public class ListCountryByRegionRequest : BaseRequest
    {
  	 public Guid RegionId { get; set; }
    }
}
