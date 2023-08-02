using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;
using SaamAppLib.SharedKernel;
using SaamAppLib.SharedKernel.Interfaces;

namespace SaamApp.Domain.Entities
{
    public class Gender : BaseEntityEv<Guid>, IAggregateRoot
    {
        private readonly List<Advisor> _advisors = new();

        private readonly List<Customer> _customers = new();


        private Gender() { } // EF required

        //[SetsRequiredMembers]
        public Gender(Guid genderId, string genderName)
        {
            GenderId = Guard.Against.NullOrEmpty(genderId, nameof(genderId));
            GenderName = Guard.Against.NullOrWhiteSpace(genderName, nameof(genderName));
        }

        [Key] public Guid GenderId { get; private set; }

        public string GenderName { get; private set; }
        public IEnumerable<Advisor> Advisors => _advisors.AsReadOnly();
        public IEnumerable<Customer> Customers => _customers.AsReadOnly();

        public void SetGenderName(string genderName)
        {
            GenderName = Guard.Against.NullOrEmpty(genderName, nameof(genderName));
        }
    }
}