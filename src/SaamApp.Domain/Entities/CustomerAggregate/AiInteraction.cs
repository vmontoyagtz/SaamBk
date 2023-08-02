using System;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;
using SaamApp.Domain.Events;
using SaamAppLib.SharedKernel;
using SaamAppLib.SharedKernel.Interfaces;

namespace SaamApp.Domain.Entities
{
    public class AiInteraction : BaseEntityEv<Guid>, IAggregateRoot
    {
        private AiInteraction() { } // EF required

        //[SetsRequiredMembers]
        public AiInteraction(Guid aiInteractionId, Guid aiRobotId, Guid customerId, Guid sessionId, string? question,
            string? answer, DateTime interactionTime, bool isSuccessful)
        {
            AiInteractionId = Guard.Against.NullOrEmpty(aiInteractionId, nameof(aiInteractionId));
            AiRobotId = Guard.Against.NullOrEmpty(aiRobotId, nameof(aiRobotId));
            CustomerId = Guard.Against.NullOrEmpty(customerId, nameof(customerId));
            SessionId = Guard.Against.NullOrEmpty(sessionId, nameof(sessionId));
            Question = question;
            Answer = answer;
            InteractionTime = Guard.Against.OutOfSQLDateRange(interactionTime, nameof(interactionTime));
            IsSuccessful = Guard.Against.Null(isSuccessful, nameof(isSuccessful));
        }

        [Key] public Guid AiInteractionId { get; private set; }

        public string? Question { get; private set; }

        public string? Answer { get; private set; }

        public DateTime InteractionTime { get; private set; }

        public bool IsSuccessful { get; private set; }

        public virtual AiRobot AiRobot { get; private set; }

        public Guid AiRobotId { get; private set; }

        public virtual Customer Customer { get; private set; }

        public Guid CustomerId { get; private set; }

        public virtual UserSession Session { get; private set; }

        public Guid SessionId { get; private set; }

        public void SetQuestion(string question)
        {
            Question = question;
        }

        public void SetAnswer(string answer)
        {
            Answer = answer;
        }

        public void UpdateCustomerForAiInteraction(Guid newCustomerId)
        {
            Guard.Against.NullOrEmpty(newCustomerId, nameof(newCustomerId));
            if (newCustomerId == CustomerId)
            {
                return;
            }

            CustomerId = newCustomerId;
            var aiInteractionUpdatedEvent = new AiInteractionUpdatedEvent(this, "Mongo-History");
            Events.Add(aiInteractionUpdatedEvent);
        }


        public void UpdateAiRobotForAiInteraction(Guid newAiRobotId)
        {
            Guard.Against.NullOrEmpty(newAiRobotId, nameof(newAiRobotId));
            if (newAiRobotId == AiRobotId)
            {
                return;
            }

            AiRobotId = newAiRobotId;
            var aiInteractionUpdatedEvent = new AiInteractionUpdatedEvent(this, "Mongo-History");
            Events.Add(aiInteractionUpdatedEvent);
        }


        public void UpdateUserSessionForAiInteraction(Guid newSessionId)
        {
            Guard.Against.NullOrEmpty(newSessionId, nameof(newSessionId));
            if (newSessionId == SessionId)
            {
                return;
            }

            SessionId = newSessionId;
            var aiInteractionUpdatedEvent = new AiInteractionUpdatedEvent(this, "Mongo-History");
            Events.Add(aiInteractionUpdatedEvent);
        }
    }
}