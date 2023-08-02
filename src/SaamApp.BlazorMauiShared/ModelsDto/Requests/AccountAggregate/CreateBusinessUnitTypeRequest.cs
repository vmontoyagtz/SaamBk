namespace SaamApp.BlazorMauiShared.Models.BusinessUnitType
{
    public class CreateBusinessUnitTypeRequest : BaseRequest
    {
        public string BusinessUnitTypeName { get; set; }
        public string? BusinessUnitTypeDescription { get; set; }
    }
}