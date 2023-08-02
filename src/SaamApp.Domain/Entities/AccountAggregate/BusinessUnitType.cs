using System;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;
using SaamAppLib.SharedKernel;
using SaamAppLib.SharedKernel.Interfaces;

namespace SaamApp.Domain.Entities
{
    public class BusinessUnitType : BaseEntityEv<Guid>, IAggregateRoot
    {
        private BusinessUnitType() { } // EF required

        //[SetsRequiredMembers]
        public BusinessUnitType(Guid businessUnitTypeId, string businessUnitTypeName,
            string? businessUnitTypeDescription)
        {
            BusinessUnitTypeId = Guard.Against.NullOrEmpty(businessUnitTypeId, nameof(businessUnitTypeId));
            BusinessUnitTypeName = Guard.Against.NullOrWhiteSpace(businessUnitTypeName, nameof(businessUnitTypeName));
            BusinessUnitTypeDescription = businessUnitTypeDescription;
        }

        [Key] public Guid BusinessUnitTypeId { get; private set; }

        public string BusinessUnitTypeName { get; private set; }

        public string? BusinessUnitTypeDescription { get; private set; }

        public void SetBusinessUnitTypeName(string businessUnitTypeName)
        {
            BusinessUnitTypeName = Guard.Against.NullOrEmpty(businessUnitTypeName, nameof(businessUnitTypeName));
        }

        public void SetBusinessUnitTypeDescription(string businessUnitTypeDescription)
        {
            BusinessUnitTypeDescription = businessUnitTypeDescription;
        }
    }
}