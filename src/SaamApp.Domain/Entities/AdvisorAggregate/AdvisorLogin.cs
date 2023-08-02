using System;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;
using SaamApp.Domain.Events;
using SaamAppLib.SharedKernel;
using SaamAppLib.SharedKernel.Interfaces;

namespace SaamApp.Domain.Entities
{
    public class AdvisorLogin : BaseEntityEv<Guid>, IAggregateRoot
    {
        private AdvisorLogin() { } // EF required

        //[SetsRequiredMembers]
        public AdvisorLogin(Guid advisorLoginId, Guid advisorId, DateTime advisorLoginDateTime, bool advisorLoginStage)
        {
            AdvisorLoginId = Guard.Against.NullOrEmpty(advisorLoginId, nameof(advisorLoginId));
            AdvisorId = Guard.Against.NullOrEmpty(advisorId, nameof(advisorId));
            AdvisorLoginDateTime = Guard.Against.OutOfSQLDateRange(advisorLoginDateTime, nameof(advisorLoginDateTime));
            AdvisorLoginStage = Guard.Against.Null(advisorLoginStage, nameof(advisorLoginStage));
        }

        [Key] public Guid AdvisorLoginId { get; private set; }

        public DateTime AdvisorLoginDateTime { get; private set; }

        public bool AdvisorLoginStage { get; private set; }

        public virtual Advisor Advisor { get; private set; }

        public Guid AdvisorId { get; private set; }


        public void UpdateAdvisorForAdvisorLogin(Guid newAdvisorId)
        {
            Guard.Against.NullOrEmpty(newAdvisorId, nameof(newAdvisorId));
            if (newAdvisorId == AdvisorId)
            {
                return;
            }

            AdvisorId = newAdvisorId;
            var advisorLoginUpdatedEvent = new AdvisorLoginUpdatedEvent(this, "Mongo-History");
            Events.Add(advisorLoginUpdatedEvent);
        }
    }
}