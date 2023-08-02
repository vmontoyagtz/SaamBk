using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;
using SaamAppLib.SharedKernel;
using SaamAppLib.SharedKernel.Interfaces;

namespace SaamApp.Domain.Entities
{
    public class MessageType : BaseEntityEv<Guid>, IAggregateRoot
    {
        private readonly List<Message> _messages = new();


        private MessageType() { } // EF required

        //[SetsRequiredMembers]
        public MessageType(Guid messageTypeId, string messageTypeName, string? messageTypeDescription)
        {
            MessageTypeId = Guard.Against.NullOrEmpty(messageTypeId, nameof(messageTypeId));
            MessageTypeName = Guard.Against.NullOrWhiteSpace(messageTypeName, nameof(messageTypeName));
            MessageTypeDescription = messageTypeDescription;
        }

        [Key] public Guid MessageTypeId { get; private set; }

        public string MessageTypeName { get; private set; }

        public string? MessageTypeDescription { get; private set; }
        public IEnumerable<Message> Messages => _messages.AsReadOnly();

        public void SetMessageTypeName(string messageTypeName)
        {
            MessageTypeName = Guard.Against.NullOrEmpty(messageTypeName, nameof(messageTypeName));
        }

        public void SetMessageTypeDescription(string messageTypeDescription)
        {
            MessageTypeDescription = messageTypeDescription;
        }
    }
}