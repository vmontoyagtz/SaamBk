using System;
using Ardalis.GuardClauses;
using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class AdvisorByIdWithIncludesSpec : Specification<Advisor>, ISingleResultSpecification
    {
        public AdvisorByIdWithIncludesSpec(Guid advisorId)
        {
            Guard.Against.NullOrEmpty(advisorId, nameof(advisorId));
            Query.Where(advisor => advisor.AdvisorId == advisorId)
                .Include(a => a.BusinessUnit)
                .Include(b => b.Gender)
                .Include(c => c.PaymentFrequency)
                .Include(d => d.TaxInformation)
                .Include(e => e.AdvisorAddresses)
                .ThenInclude(f => f.Address).Include(f => f.AdvisorAddresses).ThenInclude(f => f.AddressType)
                .Include(f => f.AdvisorBanks)
                .ThenInclude(g => g.BankAccount)
                .Include(g => g.AdvisorBankTransferInfoes)
                .ThenInclude(h => h.BankAccount)
                .Include(h => h.AdvisorCustomers)
                .ThenInclude(i => i.Customer)
                .Include(i => i.AdvisorDocuments)
                .ThenInclude(j => j.Document).Include(j => j.AdvisorDocuments).ThenInclude(j => j.DocumentType)
                .Include(j => j.AdvisorEmailAddresses)
                .ThenInclude(k => k.EmailAddress).Include(k => k.AdvisorEmailAddresses)
                .ThenInclude(k => k.EmailAddressType)
                .Include(k => k.AdvisorIdentityDocuments)
                .ThenInclude(l => l.Document).Include(l => l.AdvisorIdentityDocuments).ThenInclude(l => l.DocumentType)
                .Include(l => l.AdvisorIdentityDocuments).ThenInclude(l => l.IdentityDocument)
                .Include(l => l.AdvisorLogins)
                .Include(l => l.AdvisorPayments)
                .ThenInclude(m => m.BankAccount).Include(m => m.AdvisorPayments).ThenInclude(m => m.PaymentMethod)
                .Include(m => m.AdvisorPhoneNumbers)
                .ThenInclude(n => n.PhoneNumber).Include(n => n.AdvisorPhoneNumbers).ThenInclude(n => n.PhoneNumberType)
                .Include(n => n.AdvisorRatings)
                .ThenInclude(o => o.Conversation).Include(o => o.AdvisorRatings).ThenInclude(o => o.Customer)
                .Include(o => o.AdvisorRatings).ThenInclude(o => o.RatingReason)
                .Include(o => o.AppointmentSchedules)
                .ThenInclude(p => p.Customer)
                .Include(p => p.CustomerReviews)
                .ThenInclude(q => q.Customer)
                .Include(q => q.Messages)
                .Include(r => r.RegionAreaAdvisorCategories)
                .ThenInclude(r => r.Messages)
                .Include(s => s.TrainingProgresses)
                .ThenInclude(t => t.TrainingLesson)
                .Include(t => t.TrainingQuizHistories)
                .AsNoTracking();
        }
    }
}