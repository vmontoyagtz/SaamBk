using System;

namespace SaamAppLib.SharedKernel
{
    public class OutBoxMessage
    {
        // In C#, the protected access modifier restricts access to members of a class or its derived classes.
        // This means that only the class itself and its subclasses (derived classes) can access the protected member.

        // access to a member to within the class and its derived classes.

        public Guid EventId { get; protected set; }
        public string? Consumer { get; set; }
        public string EventType { get; set; }
        public string EntityNameType { get; set; }
        public string? ActionOnMessageReceived { get; set; }
        public string? Content { get; set; }
        public DateTime? OccurredOnUtc { get; set; }
        public DateTime? ProcessedOnUtc { get; set; }
    }
}