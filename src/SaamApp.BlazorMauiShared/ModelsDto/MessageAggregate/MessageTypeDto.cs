using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;

namespace SaamApp.Domain.ModelsDto
{
    public class MessageTypeDto
    {
        public MessageTypeDto() { } // AutoMapper required

        public MessageTypeDto(Guid messageTypeId, string messageTypeName, string? messageTypeDescription)
        {
            MessageTypeId = Guard.Against.NullOrEmpty(messageTypeId, nameof(messageTypeId));
            MessageTypeName = Guard.Against.NullOrWhiteSpace(messageTypeName, nameof(messageTypeName));
            MessageTypeDescription = messageTypeDescription;
        }

        public Guid MessageTypeId { get; set; }

        [Required(ErrorMessage = "Message Type Name is required")]
        [MaxLength(100)]
        public string MessageTypeName { get; set; }

        [MaxLength(100)] public string? MessageTypeDescription { get; set; }

        public List<MessageDto> Messages { get; set; } = new();
    }
}