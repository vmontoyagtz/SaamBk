using System;
using Ardalis.GuardClauses;
using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class CustomerByIdWithIncludesSpec : Specification<Customer>, ISingleResultSpecification
    {
        public CustomerByIdWithIncludesSpec(Guid customerId)
        {
            Guard.Against.NullOrEmpty(customerId, nameof(customerId));
            Query.Where(customer => customer.CustomerId == customerId)
                .Include(a => a.Gender)
                .Include(b => b.AdvisorCustomers)
                .ThenInclude(c => c.Advisor)
                .Include(c => c.AdvisorRatings)
                .ThenInclude(d => d.Advisor).Include(d => d.AdvisorRatings).ThenInclude(d => d.Conversation)
                .Include(d => d.AdvisorRatings).ThenInclude(d => d.RatingReason)
                .Include(d => d.AiFeedbacks)
                .Include(d => d.AiInteractions)
                .Include(e => e.AiSessions)
                .Include(e => e.AppointmentSchedules)
                .ThenInclude(f => f.Advisor)
                .Include(f => f.CustomerAccounts)
                .ThenInclude(g => g.Account)
                .Include(g => g.CustomerAddresses)
                .ThenInclude(h => h.Address).Include(h => h.CustomerAddresses).ThenInclude(h => h.AddressType)
                .Include(h => h.CustomerAiHistories)
                .Include(h => h.CustomerDocuments)
                .ThenInclude(i => i.Document).Include(i => i.CustomerDocuments).ThenInclude(i => i.DocumentType)
                .Include(i => i.CustomerEmailAddresses)
                .ThenInclude(j => j.EmailAddress).Include(j => j.CustomerEmailAddresses)
                .ThenInclude(j => j.EmailAddressType)
                .Include(j => j.CustomerFeedbacks)
                .Include(j => j.CustomerPhoneNumbers)
                .ThenInclude(k => k.PhoneNumber).Include(k => k.CustomerPhoneNumbers)
                .ThenInclude(k => k.PhoneNumberType)
                .Include(k => k.CustomerPurchases)
                .Include(k => k.CustomerReviews)
                .ThenInclude(l => l.Advisor)
                .Include(l => l.DiscountCodeRedemptions)
                .ThenInclude(m => m.DiscountCode)
                .Include(m => m.GiftCodeRedemptions)
                .ThenInclude(n => n.GiftCode)
                .Include(n => n.Messages)
                .Include(o => o.PrepaidPackageRedemptions)
                .ThenInclude(p => p.PrepaidPackage)
                .Include(p => p.SerfinsaPayments)
                .Include(q => q.UnansweredConversations)
                .AsNoTracking();
        }
    }
}