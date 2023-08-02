using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;

namespace SaamApp.Domain.ModelsDto
{
    public class GenderDto
    {
        public GenderDto() { } // AutoMapper required

        public GenderDto(Guid genderId, string genderName)
        {
            GenderId = Guard.Against.NullOrEmpty(genderId, nameof(genderId));
            GenderName = Guard.Against.NullOrWhiteSpace(genderName, nameof(genderName));
        }

        public Guid GenderId { get; set; }

        [Required(ErrorMessage = "Gender Name is required")]
        [MaxLength(100)]
        public string GenderName { get; set; }

        public List<AdvisorDto> Advisors { get; set; } = new();
        public List<CustomerDto> Customers { get; set; } = new();
    }
}