using Newtonsoft.Json;

namespace SaamAppLib.SharedKernel
{
    public sealed class JsonSerializerSettingsSingleton
    {
        // https://www.newtonsoft.com/json/help/html/T_Newtonsoft_Json_JsonSerializerSettings.htm

        private JsonSerializerSettingsSingleton() { }

        public static JsonSerializerSettings Instance { get; } = new()
        {
            TypeNameHandling = TypeNameHandling.All,
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            PreserveReferencesHandling = PreserveReferencesHandling.All,
            NullValueHandling = NullValueHandling.Include,
            DateFormatHandling = DateFormatHandling.IsoDateFormat
        };
    }
}