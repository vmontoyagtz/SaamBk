using System.Collections.Generic;
using System.Linq;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Exceptions;

namespace Ardalis.GuardClauses
{
    public static class ConversationPaymentGuardExtensions
    {
        public static void DuplicateConversationPayment(this IGuardClause guardClause,
            IEnumerable<ConversationPayment> existingConversationPayments, ConversationPayment newConversationPayment,
            string parameterName)
        {
            if (existingConversationPayments.Any(a => a.RowId == newConversationPayment.RowId))
            {
                throw new DuplicateConversationPaymentException("Cannot add duplicate conversationPayment.",
                    parameterName);
            }
        }
    }
}