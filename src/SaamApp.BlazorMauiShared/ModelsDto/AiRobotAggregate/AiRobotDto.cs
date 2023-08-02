using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;

namespace SaamApp.Domain.ModelsDto
{
    public class AiRobotDto
    {
        public AiRobotDto() { } // AutoMapper required

        public AiRobotDto(Guid aiRobotId, string aiRobotName, string? aiRobotDescription, decimal aiRobotUnitPrice,
            bool aiRobotIsActive, DateTime createdAt, Guid createdBy, DateTime? updatedAt, Guid? updatedBy,
            bool? isDeleted, Guid tenantId)
        {
            AiRobotId = Guard.Against.NullOrEmpty(aiRobotId, nameof(aiRobotId));
            AiRobotName = Guard.Against.NullOrWhiteSpace(aiRobotName, nameof(aiRobotName));
            AiRobotDescription = aiRobotDescription;
            AiRobotUnitPrice = Guard.Against.Negative(aiRobotUnitPrice, nameof(aiRobotUnitPrice));
            AiRobotIsActive = Guard.Against.Null(aiRobotIsActive, nameof(aiRobotIsActive));
            CreatedAt = Guard.Against.OutOfSQLDateRange(createdAt, nameof(createdAt));
            CreatedBy = Guard.Against.NullOrEmpty(createdBy, nameof(createdBy));
            UpdatedAt = updatedAt;
            UpdatedBy = updatedBy;
            IsDeleted = isDeleted;
            TenantId = Guard.Against.NullOrEmpty(tenantId, nameof(tenantId));
        }

        public Guid AiRobotId { get; set; }

        [Required(ErrorMessage = "Ai Robot Name is required")]
        [MaxLength(100)]
        public string AiRobotName { get; set; }

        [MaxLength(100)] public string? AiRobotDescription { get; set; }

        [Required(ErrorMessage = "Ai Robot Unit Price is required")]
        public decimal AiRobotUnitPrice { get; set; }

        [Required(ErrorMessage = "Ai Robot Is Active is required")]
        public bool AiRobotIsActive { get; set; }

        [Required(ErrorMessage = "Created At is required")]
        public DateTime CreatedAt { get; set; }

        [Required(ErrorMessage = "Created By is required")]
        public Guid CreatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public Guid? UpdatedBy { get; set; }

        public bool? IsDeleted { get; set; }

        [Required(ErrorMessage = "Tenant Id is required")]
        public Guid TenantId { get; set; }

        public List<AiInteractionDto> AiInteractions { get; set; } = new();
        public List<AiRobotCategoryDto> AiRobotCategories { get; set; } = new();
    }
}