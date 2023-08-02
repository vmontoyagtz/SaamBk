using System;
using Ardalis.GuardClauses;
using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class GetAdvisorAddressWithAdvisorKeySpec : Specification<AdvisorAddress>
    {
        public GetAdvisorAddressWithAdvisorKeySpec(Guid advisorId)
        {
            Guard.Against.NullOrEmpty(advisorId, nameof(advisorId));
            Query.Where(aa => aa.AdvisorId == advisorId).AsNoTracking();
        }
    }

    public class GetAdvisorBankWithAdvisorKeySpec : Specification<AdvisorBank>
    {
        public GetAdvisorBankWithAdvisorKeySpec(Guid advisorId)
        {
            Guard.Against.NullOrEmpty(advisorId, nameof(advisorId));
            Query.Where(ab => ab.AdvisorId == advisorId).AsNoTracking();
        }
    }

    public class GetAdvisorBankTransferInfoWithAdvisorKeySpec : Specification<AdvisorBankTransferInfo>
    {
        public GetAdvisorBankTransferInfoWithAdvisorKeySpec(Guid advisorId)
        {
            Guard.Against.NullOrEmpty(advisorId, nameof(advisorId));
            Query.Where(abti => abti.AdvisorId == advisorId).AsNoTracking();
        }
    }

    public class GetAdvisorCustomerWithAdvisorKeySpec : Specification<AdvisorCustomer>
    {
        public GetAdvisorCustomerWithAdvisorKeySpec(Guid advisorId)
        {
            Guard.Against.NullOrEmpty(advisorId, nameof(advisorId));
            Query.Where(ac => ac.AdvisorId == advisorId).AsNoTracking();
        }
    }

    public class GetAdvisorDocumentWithAdvisorKeySpec : Specification<AdvisorDocument>
    {
        public GetAdvisorDocumentWithAdvisorKeySpec(Guid advisorId)
        {
            Guard.Against.NullOrEmpty(advisorId, nameof(advisorId));
            Query.Where(ad => ad.AdvisorId == advisorId).AsNoTracking();
        }
    }

    public class GetAdvisorEmailAddressWithAdvisorKeySpec : Specification<AdvisorEmailAddress>
    {
        public GetAdvisorEmailAddressWithAdvisorKeySpec(Guid advisorId)
        {
            Guard.Against.NullOrEmpty(advisorId, nameof(advisorId));
            Query.Where(aea => aea.AdvisorId == advisorId).AsNoTracking();
        }
    }

    public class GetAdvisorIdentityDocumentWithAdvisorKeySpec : Specification<AdvisorIdentityDocument>
    {
        public GetAdvisorIdentityDocumentWithAdvisorKeySpec(Guid advisorId)
        {
            Guard.Against.NullOrEmpty(advisorId, nameof(advisorId));
            Query.Where(aid => aid.AdvisorId == advisorId).AsNoTracking();
        }
    }

    public class GetAdvisorLoginWithAdvisorKeySpec : Specification<AdvisorLogin>
    {
        public GetAdvisorLoginWithAdvisorKeySpec(Guid advisorId)
        {
            Guard.Against.NullOrEmpty(advisorId, nameof(advisorId));
            Query.Where(al => al.AdvisorId == advisorId).AsNoTracking();
        }
    }

    public class GetAdvisorPaymentWithAdvisorKeySpec : Specification<AdvisorPayment>
    {
        public GetAdvisorPaymentWithAdvisorKeySpec(Guid advisorId)
        {
            Guard.Against.NullOrEmpty(advisorId, nameof(advisorId));
            Query.Where(ap => ap.AdvisorId == advisorId).AsNoTracking();
        }
    }

    public class GetAdvisorPhoneNumberWithAdvisorKeySpec : Specification<AdvisorPhoneNumber>
    {
        public GetAdvisorPhoneNumberWithAdvisorKeySpec(Guid advisorId)
        {
            Guard.Against.NullOrEmpty(advisorId, nameof(advisorId));
            Query.Where(apn => apn.AdvisorId == advisorId).AsNoTracking();
        }
    }

    public class GetAdvisorRatingWithAdvisorKeySpec : Specification<AdvisorRating>
    {
        public GetAdvisorRatingWithAdvisorKeySpec(Guid advisorId)
        {
            Guard.Against.NullOrEmpty(advisorId, nameof(advisorId));
            Query.Where(ar => ar.AdvisorId == advisorId).AsNoTracking();
        }
    }

    public class GetAppointmentScheduleWithAdvisorKeySpec : Specification<AppointmentSchedule>
    {
        public GetAppointmentScheduleWithAdvisorKeySpec(Guid advisorId)
        {
            Guard.Against.NullOrEmpty(advisorId, nameof(advisorId));
            Query.Where(as1 => as1.AdvisorId == advisorId).AsNoTracking();
        }
    }

    public class GetCustomerReviewWithAdvisorKeySpec : Specification<CustomerReview>
    {
        public GetCustomerReviewWithAdvisorKeySpec(Guid advisorId)
        {
            Guard.Against.NullOrEmpty(advisorId, nameof(advisorId));
            Query.Where(cr => cr.AdvisorId == advisorId).AsNoTracking();
        }
    }

    public class GetMessageWithAdvisorKeySpec : Specification<Message>
    {
        public GetMessageWithAdvisorKeySpec(Guid advisorId)
        {
            Guard.Against.NullOrEmpty(advisorId, nameof(advisorId));
            Query.Where(m => m.AdvisorId == advisorId).AsNoTracking();
        }
    }

    public class GetRegionAreaAdvisorCategoryWithAdvisorKeySpec : Specification<RegionAreaAdvisorCategory>
    {
        public GetRegionAreaAdvisorCategoryWithAdvisorKeySpec(Guid advisorId)
        {
            Guard.Against.NullOrEmpty(advisorId, nameof(advisorId));
            Query.Where(raac => raac.AdvisorId == advisorId).AsNoTracking();
        }
    }

    public class GetTrainingProgressWithAdvisorKeySpec : Specification<TrainingProgress>
    {
        public GetTrainingProgressWithAdvisorKeySpec(Guid advisorId)
        {
            Guard.Against.NullOrEmpty(advisorId, nameof(advisorId));
            Query.Where(tp => tp.AdvisorId == advisorId).AsNoTracking();
        }
    }

    public class GetTrainingQuizHistoryWithAdvisorKeySpec : Specification<TrainingQuizHistory>
    {
        public GetTrainingQuizHistoryWithAdvisorKeySpec(Guid advisorId)
        {
            Guard.Against.NullOrEmpty(advisorId, nameof(advisorId));
            Query.Where(tqh => tqh.AdvisorId == advisorId).AsNoTracking();
        }
    }
}