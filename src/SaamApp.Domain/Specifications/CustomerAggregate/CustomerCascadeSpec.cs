using System;
using Ardalis.GuardClauses;
using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class GetAdvisorCustomerWithCustomerKeySpec : Specification<AdvisorCustomer>
    {
        public GetAdvisorCustomerWithCustomerKeySpec(Guid customerId)
        {
            Guard.Against.NullOrEmpty(customerId, nameof(customerId));
            Query.Where(ac => ac.CustomerId == customerId).AsNoTracking();
        }
    }

    public class GetAdvisorRatingWithCustomerKeySpec : Specification<AdvisorRating>
    {
        public GetAdvisorRatingWithCustomerKeySpec(Guid customerId)
        {
            Guard.Against.NullOrEmpty(customerId, nameof(customerId));
            Query.Where(ar => ar.CustomerId == customerId).AsNoTracking();
        }
    }

    public class GetAiFeedbackWithCustomerKeySpec : Specification<AiFeedback>
    {
        public GetAiFeedbackWithCustomerKeySpec(Guid customerId)
        {
            Guard.Against.NullOrEmpty(customerId, nameof(customerId));
            Query.Where(af => af.CustomerId == customerId).AsNoTracking();
        }
    }

    public class GetAiInteractionWithCustomerKeySpec : Specification<AiInteraction>
    {
        public GetAiInteractionWithCustomerKeySpec(Guid customerId)
        {
            Guard.Against.NullOrEmpty(customerId, nameof(customerId));
            Query.Where(ai => ai.CustomerId == customerId).AsNoTracking();
        }
    }

    public class GetAiSessionWithCustomerKeySpec : Specification<AiSession>
    {
        public GetAiSessionWithCustomerKeySpec(Guid customerId)
        {
            Guard.Against.NullOrEmpty(customerId, nameof(customerId));
            Query.Where(as1 => as1.CustomerId == customerId).AsNoTracking();
        }
    }

    public class GetAppointmentScheduleWithCustomerKeySpec : Specification<AppointmentSchedule>
    {
        public GetAppointmentScheduleWithCustomerKeySpec(Guid customerId)
        {
            Guard.Against.NullOrEmpty(customerId, nameof(customerId));
            Query.Where(as1 => as1.CustomerId == customerId).AsNoTracking();
        }
    }

    public class GetCustomerAccountWithCustomerKeySpec : Specification<CustomerAccount>
    {
        public GetCustomerAccountWithCustomerKeySpec(Guid customerId)
        {
            Guard.Against.NullOrEmpty(customerId, nameof(customerId));
            Query.Where(ca => ca.CustomerId == customerId).AsNoTracking();
        }
    }

    public class GetCustomerAddressWithCustomerKeySpec : Specification<CustomerAddress>
    {
        public GetCustomerAddressWithCustomerKeySpec(Guid customerId)
        {
            Guard.Against.NullOrEmpty(customerId, nameof(customerId));
            Query.Where(ca => ca.CustomerId == customerId).AsNoTracking();
        }
    }

    public class GetCustomerAiHistoryWithCustomerKeySpec : Specification<CustomerAiHistory>
    {
        public GetCustomerAiHistoryWithCustomerKeySpec(Guid customerId)
        {
            Guard.Against.NullOrEmpty(customerId, nameof(customerId));
            Query.Where(cah => cah.CustomerId == customerId).AsNoTracking();
        }
    }

    public class GetCustomerDocumentWithCustomerKeySpec : Specification<CustomerDocument>
    {
        public GetCustomerDocumentWithCustomerKeySpec(Guid customerId)
        {
            Guard.Against.NullOrEmpty(customerId, nameof(customerId));
            Query.Where(cd => cd.CustomerId == customerId).AsNoTracking();
        }
    }

    public class GetCustomerEmailAddressWithCustomerKeySpec : Specification<CustomerEmailAddress>
    {
        public GetCustomerEmailAddressWithCustomerKeySpec(Guid customerId)
        {
            Guard.Against.NullOrEmpty(customerId, nameof(customerId));
            Query.Where(cea => cea.CustomerId == customerId).AsNoTracking();
        }
    }

    public class GetCustomerFeedbackWithCustomerKeySpec : Specification<CustomerFeedback>
    {
        public GetCustomerFeedbackWithCustomerKeySpec(Guid customerId)
        {
            Guard.Against.NullOrEmpty(customerId, nameof(customerId));
            Query.Where(cf => cf.CustomerId == customerId).AsNoTracking();
        }
    }

    public class GetCustomerPhoneNumberWithCustomerKeySpec : Specification<CustomerPhoneNumber>
    {
        public GetCustomerPhoneNumberWithCustomerKeySpec(Guid customerId)
        {
            Guard.Against.NullOrEmpty(customerId, nameof(customerId));
            Query.Where(cpn => cpn.CustomerId == customerId).AsNoTracking();
        }
    }

    public class GetCustomerPurchaseWithCustomerKeySpec : Specification<CustomerPurchase>
    {
        public GetCustomerPurchaseWithCustomerKeySpec(Guid customerId)
        {
            Guard.Against.NullOrEmpty(customerId, nameof(customerId));
            Query.Where(cp => cp.CustomerId == customerId).AsNoTracking();
        }
    }

    public class GetCustomerReviewWithCustomerKeySpec : Specification<CustomerReview>
    {
        public GetCustomerReviewWithCustomerKeySpec(Guid customerId)
        {
            Guard.Against.NullOrEmpty(customerId, nameof(customerId));
            Query.Where(cr => cr.CustomerId == customerId).AsNoTracking();
        }
    }

    public class GetDiscountCodeRedemptionWithCustomerKeySpec : Specification<DiscountCodeRedemption>
    {
        public GetDiscountCodeRedemptionWithCustomerKeySpec(Guid customerId)
        {
            Guard.Against.NullOrEmpty(customerId, nameof(customerId));
            Query.Where(dcr => dcr.CustomerId == customerId).AsNoTracking();
        }
    }

    public class GetGiftCodeRedemptionWithCustomerKeySpec : Specification<GiftCodeRedemption>
    {
        public GetGiftCodeRedemptionWithCustomerKeySpec(Guid customerId)
        {
            Guard.Against.NullOrEmpty(customerId, nameof(customerId));
            Query.Where(gcr => gcr.CustomerId == customerId).AsNoTracking();
        }
    }

    public class GetMessageWithCustomerKeySpec : Specification<Message>
    {
        public GetMessageWithCustomerKeySpec(Guid customerId)
        {
            Guard.Against.NullOrEmpty(customerId, nameof(customerId));
            Query.Where(m => m.CustomerId == customerId).AsNoTracking();
        }
    }

    public class GetPrepaidPackageRedemptionWithCustomerKeySpec : Specification<PrepaidPackageRedemption>
    {
        public GetPrepaidPackageRedemptionWithCustomerKeySpec(Guid customerId)
        {
            Guard.Against.NullOrEmpty(customerId, nameof(customerId));
            Query.Where(ppr => ppr.CustomerId == customerId).AsNoTracking();
        }
    }

    public class GetSerfinsaPaymentWithCustomerKeySpec : Specification<SerfinsaPayment>
    {
        public GetSerfinsaPaymentWithCustomerKeySpec(Guid customerId)
        {
            Guard.Against.NullOrEmpty(customerId, nameof(customerId));
            Query.Where(sp => sp.CustomerId == customerId).AsNoTracking();
        }
    }

    public class GetUnansweredConversationWithCustomerKeySpec : Specification<UnansweredConversation>
    {
        public GetUnansweredConversationWithCustomerKeySpec(Guid customerId)
        {
            Guard.Against.NullOrEmpty(customerId, nameof(customerId));
            Query.Where(uc => uc.CustomerId == customerId).AsNoTracking();
        }
    }
}