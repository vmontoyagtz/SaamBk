using System.Collections.Generic;
using System.Linq;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Exceptions;

namespace Ardalis.GuardClauses
{
    public static class AiFeedbackGuardExtensions
    {
        public static void DuplicateAiFeedback(this IGuardClause guardClause,
            IEnumerable<AiFeedback> existingAiFeedbacks, AiFeedback newAiFeedback, string parameterName)
        {
            if (existingAiFeedbacks.Any(a => a.AiFeedbackId == newAiFeedback.AiFeedbackId))
            {
                throw new DuplicateAiFeedbackException("Cannot add duplicate aiFeedback.", parameterName);
            }
        }
    }
}