using System;

namespace SaamApp.Domain.Exceptions
{
    public class AppConfigParamNotFoundException : Exception
    {
        public AppConfigParamNotFoundException(string message) : base(message)
        {
        }

        public AppConfigParamNotFoundException(Guid appConfigParamId) : base(
            $"No appConfigParam with id {appConfigParamId} found.")
        {
        }
    }
}