using System;

namespace SaamApp.BlazorMauiShared.Models
{
    public abstract class BaseMessage
    {
        protected Guid _correlationId = Guid.NewGuid();

        public Guid CorrelationId()
        {
            return _correlationId;
        }
    }
}