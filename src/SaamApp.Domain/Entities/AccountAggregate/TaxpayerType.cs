using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;
using SaamAppLib.SharedKernel;
using SaamAppLib.SharedKernel.Interfaces;

namespace SaamApp.Domain.Entities
{
    public class TaxpayerType : BaseEntityEv<Guid>, IAggregateRoot
    {
        private readonly List<TaxInformation> _taxInformations = new();


        private TaxpayerType() { } // EF required

        //[SetsRequiredMembers]
        public TaxpayerType(Guid taxpayerTypeId, string taxpayerTypeName, Guid tenantId)
        {
            TaxpayerTypeId = Guard.Against.NullOrEmpty(taxpayerTypeId, nameof(taxpayerTypeId));
            TaxpayerTypeName = Guard.Against.NullOrWhiteSpace(taxpayerTypeName, nameof(taxpayerTypeName));
            TenantId = Guard.Against.NullOrEmpty(tenantId, nameof(tenantId));
        }

        [Key] public Guid TaxpayerTypeId { get; private set; }

        public string TaxpayerTypeName { get; private set; }

        public Guid TenantId { get; private set; }
        public IEnumerable<TaxInformation> TaxInformations => _taxInformations.AsReadOnly();

        public void SetTaxpayerTypeName(string taxpayerTypeName)
        {
            TaxpayerTypeName = Guard.Against.NullOrEmpty(taxpayerTypeName, nameof(taxpayerTypeName));
        }
    }
}