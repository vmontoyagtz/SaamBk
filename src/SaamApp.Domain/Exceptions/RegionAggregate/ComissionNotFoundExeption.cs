using System;

namespace SaamApp.Domain.Exceptions
{
    public class ComissionNotFoundException : Exception
    {
        public ComissionNotFoundException(string message) : base(message)
        {
        }

        public ComissionNotFoundException(Guid comissionId) : base($"No comission with id {comissionId} found.")
        {
        }
    }
}