using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Ardalis.GuardClauses;
using SaamApp.Domain.Events;
using SaamAppLib.SharedKernel;
using SaamAppLib.SharedKernel.Interfaces;

namespace SaamApp.Domain.Entities
{
    public class Customer : BaseEntityEv<Guid>, IAggregateRoot
    {
        private readonly List<AdvisorCustomer> _advisorCustomers = new();

        private readonly List<AdvisorRating> _advisorRatings = new();

        private readonly List<AiFeedback> _aiFeedbacks = new();

        private readonly List<AiInteraction> _aiInteractions = new();

        private readonly List<AiSession> _aiSessions = new();

        private readonly List<AppointmentSchedule> _appointmentSchedules = new();

        private readonly List<CustomerAccount> _customerAccounts = new();

        private readonly List<CustomerAddress> _customerAddresses = new();

        private readonly List<CustomerAiHistory> _customerAiHistories = new();

        private readonly List<CustomerDocument> _customerDocuments = new();

        private readonly List<CustomerEmailAddress> _customerEmailAddresses = new();

        private readonly List<CustomerFeedback> _customerFeedbacks = new();

        private readonly List<CustomerPhoneNumber> _customerPhoneNumbers = new();

        private readonly List<CustomerPurchase> _customerPurchases = new();

        private readonly List<CustomerReview> _customerReviews = new();

        private readonly List<DiscountCodeRedemption> _discountCodeRedemptions = new();

        private readonly List<GiftCodeRedemption> _giftCodeRedemptions = new();

        private readonly List<Message> _messages = new();

        private readonly List<PrepaidPackageRedemption> _prepaidPackageRedemptions = new();

        private readonly List<SerfinsaPayment> _serfinsaPayments = new();

        private readonly List<UnansweredConversation> _unansweredConversations = new();

        private Customer() { } // EF required

        //[SetsRequiredMembers]
        public Customer(Guid customerId, Guid genderId, string customerFirstName, string customerLastName,
            string? customerProfileThumbnailPath, DateTime? customerBirthDate, DateTime createdAt, Guid createdBy,
            DateTime? updatedAt, Guid? updatedBy, bool? isDeleted, Guid tenantId)
        {
            //https://careers.per-angusta.com/blog/common-mistakes-with-guard-clause-pattern/
            //https://github.com/ardalis/GuardClauses
            CustomerId = Guard.Against.NullOrEmpty(customerId, nameof(customerId));
            GenderId = Guard.Against.NullOrEmpty(genderId, nameof(genderId));
            CustomerFirstName = Guard.Against.NullOrWhiteSpace(customerFirstName, nameof(customerFirstName));
            CustomerLastName = Guard.Against.NullOrWhiteSpace(customerLastName, nameof(customerLastName));
            CustomerProfileThumbnailPath = customerProfileThumbnailPath;
            CustomerBirthDate = customerBirthDate;
            CreatedAt = Guard.Against.OutOfSQLDateRange(createdAt, nameof(createdAt));
            CreatedBy = Guard.Against.NullOrEmpty(createdBy, nameof(createdBy));
            UpdatedAt = updatedAt;
            UpdatedBy = updatedBy;
            IsDeleted = isDeleted;
            TenantId = Guard.Against.NullOrEmpty(tenantId, nameof(tenantId));
        }

        [Key] public Guid CustomerId { get; private set; }

        public string CustomerFirstName { get; private set; }

        public string CustomerLastName { get; private set; }

        public string? CustomerProfileThumbnailPath { get; private set; }

        public DateTime? CustomerBirthDate { get; private set; }

        public DateTime CreatedAt { get; private set; }

        public Guid CreatedBy { get; private set; }

        public DateTime? UpdatedAt { get; private set; }

        public Guid? UpdatedBy { get; private set; }

        public bool? IsDeleted { get; private set; }

        public Guid TenantId { get; private set; }

        public virtual Gender Gender { get; private set; }

        public Guid GenderId { get; private set; }
        public IEnumerable<AdvisorCustomer> AdvisorCustomers => _advisorCustomers.AsReadOnly();
        public IEnumerable<AdvisorRating> AdvisorRatings => _advisorRatings.AsReadOnly();
        public IEnumerable<AiFeedback> AiFeedbacks => _aiFeedbacks.AsReadOnly();
        public IEnumerable<AiInteraction> AiInteractions => _aiInteractions.AsReadOnly();
        public IEnumerable<AiSession> AiSessions => _aiSessions.AsReadOnly();
        public IEnumerable<AppointmentSchedule> AppointmentSchedules => _appointmentSchedules.AsReadOnly();
        public IEnumerable<CustomerAccount> CustomerAccounts => _customerAccounts.AsReadOnly();
        public IEnumerable<CustomerAddress> CustomerAddresses => _customerAddresses.AsReadOnly();
        public IEnumerable<CustomerAiHistory> CustomerAiHistories => _customerAiHistories.AsReadOnly();
        public IEnumerable<CustomerDocument> CustomerDocuments => _customerDocuments.AsReadOnly();
        public IEnumerable<CustomerEmailAddress> CustomerEmailAddresses => _customerEmailAddresses.AsReadOnly();
        public IEnumerable<CustomerFeedback> CustomerFeedbacks => _customerFeedbacks.AsReadOnly();
        public IEnumerable<CustomerPhoneNumber> CustomerPhoneNumbers => _customerPhoneNumbers.AsReadOnly();
        public IEnumerable<CustomerPurchase> CustomerPurchases => _customerPurchases.AsReadOnly();
        public IEnumerable<CustomerReview> CustomerReviews => _customerReviews.AsReadOnly();
        public IEnumerable<DiscountCodeRedemption> DiscountCodeRedemptions => _discountCodeRedemptions.AsReadOnly();
        public IEnumerable<GiftCodeRedemption> GiftCodeRedemptions => _giftCodeRedemptions.AsReadOnly();
        public IEnumerable<Message> Messages => _messages.AsReadOnly();

        public IEnumerable<PrepaidPackageRedemption> PrepaidPackageRedemptions =>
            _prepaidPackageRedemptions.AsReadOnly();

        public IEnumerable<SerfinsaPayment> SerfinsaPayments => _serfinsaPayments.AsReadOnly();
        public IEnumerable<UnansweredConversation> UnansweredConversations => _unansweredConversations.AsReadOnly();

        public void SetCustomerFirstName(string customerFirstName)
        {
            CustomerFirstName = Guard.Against.NullOrEmpty(customerFirstName, nameof(customerFirstName));
        }

        public void SetCustomerLastName(string customerLastName)
        {
            CustomerLastName = Guard.Against.NullOrEmpty(customerLastName, nameof(customerLastName));
        }

        public void SetCustomerProfileThumbnailPath(string customerProfileThumbnailPath)
        {
            CustomerProfileThumbnailPath = customerProfileThumbnailPath;
        }

        public void UpdateGenderForCustomer(Guid newGenderId)
        {
            Guard.Against.NullOrEmpty(newGenderId, nameof(newGenderId));
            if (newGenderId == GenderId)
            {
                return;
            }

            GenderId = newGenderId;
            var customerUpdatedEvent = new CustomerUpdatedEvent(this, "Mongo-History");
            Events.Add(customerUpdatedEvent);
        }


        public void AddNewAdvisorCustomer(Guid advisorId, Guid customerId)
        {
            Guard.Against.NullOrEmpty(advisorId, nameof(advisorId));
            Guard.Against.NullOrEmpty(customerId, nameof(customerId));

            var newAdvisorCustomer = new AdvisorCustomer(advisorId, customerId);
            Guard.Against.DuplicateAdvisorCustomer(_advisorCustomers, newAdvisorCustomer, nameof(newAdvisorCustomer));
            _advisorCustomers.Add(newAdvisorCustomer);
            var advisorCustomerAddedEvent = new AdvisorCustomerCreatedEvent(newAdvisorCustomer, "Mongo-History");
            Events.Add(advisorCustomerAddedEvent);
        }

        public void DeleteAdvisorCustomer(Guid advisorId, Guid customerId)
        {
            Guard.Against.NullOrEmpty(advisorId, nameof(advisorId));
            Guard.Against.NullOrEmpty(customerId, nameof(customerId));

            var advisorCustomerToDelete = _advisorCustomers
                .Where(ac1 => ac1.AdvisorId == advisorId)
                .Where(ac2 => ac2.CustomerId == customerId)
                .FirstOrDefault();

            if (advisorCustomerToDelete != null)
            {
                _advisorCustomers.Remove(advisorCustomerToDelete);
                var advisorCustomerDeletedEvent =
                    new AdvisorCustomerDeletedEvent(advisorCustomerToDelete, "Mongo-History");
                Events.Add(advisorCustomerDeletedEvent);
            }
        }

        public void AddNewAdvisorRating(string? advisorRatingFeedback, int advisorRatingRate,
            DateTime advisorRatingDate, Guid advisorId, Guid conversationId, Guid customerId, Guid ratingReasonId)
        {
            Guard.Against.NegativeOrZero(advisorRatingRate, nameof(advisorRatingRate));
            Guard.Against.OutOfSQLDateRange(advisorRatingDate, nameof(advisorRatingDate));
            Guard.Against.NullOrEmpty(advisorId, nameof(advisorId));
            Guard.Against.NullOrEmpty(conversationId, nameof(conversationId));
            Guard.Against.NullOrEmpty(customerId, nameof(customerId));
            Guard.Against.NullOrEmpty(ratingReasonId, nameof(ratingReasonId));

            var newAdvisorRating = new AdvisorRating(advisorId, conversationId, customerId, ratingReasonId,
                advisorRatingFeedback, advisorRatingRate, advisorRatingDate);
            Guard.Against.DuplicateAdvisorRating(_advisorRatings, newAdvisorRating, nameof(newAdvisorRating));
            _advisorRatings.Add(newAdvisorRating);
            var advisorRatingAddedEvent = new AdvisorRatingCreatedEvent(newAdvisorRating, "Mongo-History");
            Events.Add(advisorRatingAddedEvent);
        }

        public void DeleteAdvisorRating(string advisorRatingFeedback, int advisorRatingRate, DateTime advisorRatingDate,
            Guid advisorId, Guid conversationId, Guid customerId, Guid ratingReasonId)
        {
            Guard.Against.NullOrWhiteSpace(advisorRatingFeedback, nameof(advisorRatingFeedback));
            Guard.Against.NegativeOrZero(advisorRatingRate, nameof(advisorRatingRate));
            Guard.Against.OutOfSQLDateRange(advisorRatingDate, nameof(advisorRatingDate));
            Guard.Against.NullOrEmpty(advisorId, nameof(advisorId));
            Guard.Against.NullOrEmpty(conversationId, nameof(conversationId));
            Guard.Against.NullOrEmpty(customerId, nameof(customerId));
            Guard.Against.NullOrEmpty(ratingReasonId, nameof(ratingReasonId));

            var advisorRatingToDelete = _advisorRatings
                .Where(ar1 => ar1.AdvisorRatingFeedback == advisorRatingFeedback)
                .Where(ar2 => ar2.AdvisorRatingRate == advisorRatingRate)
                .Where(ar3 => ar3.AdvisorRatingDate == advisorRatingDate)
                .Where(ar4 => ar4.AdvisorId == advisorId)
                .Where(ar5 => ar5.ConversationId == conversationId)
                .Where(ar6 => ar6.CustomerId == customerId)
                .Where(ar7 => ar7.RatingReasonId == ratingReasonId)
                .FirstOrDefault();

            if (advisorRatingToDelete != null)
            {
                _advisorRatings.Remove(advisorRatingToDelete);
                var advisorRatingDeletedEvent = new AdvisorRatingDeletedEvent(advisorRatingToDelete, "Mongo-History");
                Events.Add(advisorRatingDeletedEvent);
            }
        }

        public void AddNewAiFeedback(AiFeedback aiFeedback)
        {
            Guard.Against.Null(aiFeedback, nameof(aiFeedback));
            Guard.Against.NullOrEmpty(aiFeedback.AiFeedbackId, nameof(aiFeedback.AiFeedbackId));
            Guard.Against.DuplicateAiFeedback(_aiFeedbacks, aiFeedback, nameof(aiFeedback));
            _aiFeedbacks.Add(aiFeedback);
            var aiFeedbackAddedEvent = new AiFeedbackCreatedEvent(aiFeedback, "Mongo-History");
            Events.Add(aiFeedbackAddedEvent);
        }

        public void DeleteAiFeedback(AiFeedback aiFeedback)
        {
            Guard.Against.Null(aiFeedback, nameof(aiFeedback));
            var aiFeedbackToDelete = _aiFeedbacks
                .Where(af => af.AiFeedbackId == aiFeedback.AiFeedbackId)
                .FirstOrDefault();
            if (aiFeedbackToDelete != null)
            {
                _aiFeedbacks.Remove(aiFeedbackToDelete);
                var aiFeedbackDeletedEvent = new AiFeedbackDeletedEvent(aiFeedbackToDelete, "Mongo-History");
                Events.Add(aiFeedbackDeletedEvent);
            }
        }

        public void AddNewAiInteraction(AiInteraction aiInteraction)
        {
            Guard.Against.Null(aiInteraction, nameof(aiInteraction));
            Guard.Against.NullOrEmpty(aiInteraction.AiInteractionId, nameof(aiInteraction.AiInteractionId));
            Guard.Against.DuplicateAiInteraction(_aiInteractions, aiInteraction, nameof(aiInteraction));
            _aiInteractions.Add(aiInteraction);
            var aiInteractionAddedEvent = new AiInteractionCreatedEvent(aiInteraction, "Mongo-History");
            Events.Add(aiInteractionAddedEvent);
        }

        public void DeleteAiInteraction(AiInteraction aiInteraction)
        {
            Guard.Against.Null(aiInteraction, nameof(aiInteraction));
            var aiInteractionToDelete = _aiInteractions
                .Where(ai => ai.AiInteractionId == aiInteraction.AiInteractionId)
                .FirstOrDefault();
            if (aiInteractionToDelete != null)
            {
                _aiInteractions.Remove(aiInteractionToDelete);
                var aiInteractionDeletedEvent = new AiInteractionDeletedEvent(aiInteractionToDelete, "Mongo-History");
                Events.Add(aiInteractionDeletedEvent);
            }
        }

        public void AddNewAiSession(AiSession aiSession)
        {
            Guard.Against.Null(aiSession, nameof(aiSession));
            Guard.Against.NullOrEmpty(aiSession.AiSessionId, nameof(aiSession.AiSessionId));
            Guard.Against.DuplicateAiSession(_aiSessions, aiSession, nameof(aiSession));
            _aiSessions.Add(aiSession);
            var aiSessionAddedEvent = new AiSessionCreatedEvent(aiSession, "Mongo-History");
            Events.Add(aiSessionAddedEvent);
        }

        public void DeleteAiSession(AiSession aiSession)
        {
            Guard.Against.Null(aiSession, nameof(aiSession));
            var aiSessionToDelete = _aiSessions
                .Where(as1 => as1.AiSessionId == aiSession.AiSessionId)
                .FirstOrDefault();
            if (aiSessionToDelete != null)
            {
                _aiSessions.Remove(aiSessionToDelete);
                var aiSessionDeletedEvent = new AiSessionDeletedEvent(aiSessionToDelete, "Mongo-History");
                Events.Add(aiSessionDeletedEvent);
            }
        }

        public void AddNewAppointmentSchedule(AppointmentSchedule appointmentSchedule)
        {
            Guard.Against.Null(appointmentSchedule, nameof(appointmentSchedule));
            Guard.Against.NullOrEmpty(appointmentSchedule.AppointmentScheduleId,
                nameof(appointmentSchedule.AppointmentScheduleId));
            Guard.Against.DuplicateAppointmentSchedule(_appointmentSchedules, appointmentSchedule,
                nameof(appointmentSchedule));
            _appointmentSchedules.Add(appointmentSchedule);
            var appointmentScheduleAddedEvent =
                new AppointmentScheduleCreatedEvent(appointmentSchedule, "Mongo-History");
            Events.Add(appointmentScheduleAddedEvent);
        }

        public void DeleteAppointmentSchedule(AppointmentSchedule appointmentSchedule)
        {
            Guard.Against.Null(appointmentSchedule, nameof(appointmentSchedule));
            var appointmentScheduleToDelete = _appointmentSchedules
                .Where(as1 => as1.AppointmentScheduleId == appointmentSchedule.AppointmentScheduleId)
                .FirstOrDefault();
            if (appointmentScheduleToDelete != null)
            {
                _appointmentSchedules.Remove(appointmentScheduleToDelete);
                var appointmentScheduleDeletedEvent =
                    new AppointmentScheduleDeletedEvent(appointmentScheduleToDelete, "Mongo-History");
                Events.Add(appointmentScheduleDeletedEvent);
            }
        }

        public void AddNewCustomerAccount(Guid accountId, Guid customerId)
        {
            Guard.Against.NullOrEmpty(accountId, nameof(accountId));
            Guard.Against.NullOrEmpty(customerId, nameof(customerId));

            var newCustomerAccount = new CustomerAccount(accountId, customerId);
            Guard.Against.DuplicateCustomerAccount(_customerAccounts, newCustomerAccount, nameof(newCustomerAccount));
            _customerAccounts.Add(newCustomerAccount);
            var customerAccountAddedEvent = new CustomerAccountCreatedEvent(newCustomerAccount, "Mongo-History");
            Events.Add(customerAccountAddedEvent);
        }

        public void DeleteCustomerAccount(Guid accountId, Guid customerId)
        {
            Guard.Against.NullOrEmpty(accountId, nameof(accountId));
            Guard.Against.NullOrEmpty(customerId, nameof(customerId));

            var customerAccountToDelete = _customerAccounts
                .Where(ca1 => ca1.AccountId == accountId)
                .Where(ca2 => ca2.CustomerId == customerId)
                .FirstOrDefault();

            if (customerAccountToDelete != null)
            {
                _customerAccounts.Remove(customerAccountToDelete);
                var customerAccountDeletedEvent =
                    new CustomerAccountDeletedEvent(customerAccountToDelete, "Mongo-History");
                Events.Add(customerAccountDeletedEvent);
            }
        }

        public void AddNewCustomerAddress(Guid addressId, Guid addressTypeId, Guid customerId)
        {
            Guard.Against.NullOrEmpty(addressId, nameof(addressId));
            Guard.Against.NullOrEmpty(addressTypeId, nameof(addressTypeId));
            Guard.Against.NullOrEmpty(customerId, nameof(customerId));

            var newCustomerAddress = new CustomerAddress(addressId, addressTypeId, customerId);
            Guard.Against.DuplicateCustomerAddress(_customerAddresses, newCustomerAddress, nameof(newCustomerAddress));
            _customerAddresses.Add(newCustomerAddress);
            var customerAddressAddedEvent = new CustomerAddressCreatedEvent(newCustomerAddress, "Mongo-History");
            Events.Add(customerAddressAddedEvent);
        }

        public void DeleteCustomerAddress(Guid addressId, Guid customerId)
        {
            Guard.Against.NullOrEmpty(addressId, nameof(addressId));
            Guard.Against.NullOrEmpty(customerId, nameof(customerId));

            var customerAddressToDelete = _customerAddresses
                .Where(ca1 => ca1.AddressId == addressId)
                .Where(ca3 => ca3.CustomerId == customerId)
                .FirstOrDefault();

            if (customerAddressToDelete != null)
            {
                _customerAddresses.Remove(customerAddressToDelete);
                var customerAddressDeletedEvent =
                    new CustomerAddressDeletedEvent(customerAddressToDelete, "Mongo-History");
                Events.Add(customerAddressDeletedEvent);
            }
        }

        public void AddNewCustomerAiHistory(CustomerAiHistory customerAiHistory)
        {
            Guard.Against.Null(customerAiHistory, nameof(customerAiHistory));
            Guard.Against.NullOrEmpty(customerAiHistory.CustomerAiHistoryId,
                nameof(customerAiHistory.CustomerAiHistoryId));
            Guard.Against.DuplicateCustomerAiHistory(_customerAiHistories, customerAiHistory,
                nameof(customerAiHistory));
            _customerAiHistories.Add(customerAiHistory);
            var customerAiHistoryAddedEvent = new CustomerAiHistoryCreatedEvent(customerAiHistory, "Mongo-History");
            Events.Add(customerAiHistoryAddedEvent);
        }

        public void DeleteCustomerAiHistory(CustomerAiHistory customerAiHistory)
        {
            Guard.Against.Null(customerAiHistory, nameof(customerAiHistory));
            var customerAiHistoryToDelete = _customerAiHistories
                .Where(cah => cah.CustomerAiHistoryId == customerAiHistory.CustomerAiHistoryId)
                .FirstOrDefault();
            if (customerAiHistoryToDelete != null)
            {
                _customerAiHistories.Remove(customerAiHistoryToDelete);
                var customerAiHistoryDeletedEvent =
                    new CustomerAiHistoryDeletedEvent(customerAiHistoryToDelete, "Mongo-History");
                Events.Add(customerAiHistoryDeletedEvent);
            }
        }

        public void AddNewCustomerDocument(Guid customerId, Guid documentId, Guid documentTypeId)
        {
            Guard.Against.NullOrEmpty(customerId, nameof(customerId));
            Guard.Against.NullOrEmpty(documentId, nameof(documentId));
            Guard.Against.NullOrEmpty(documentTypeId, nameof(documentTypeId));

            var newCustomerDocument = new CustomerDocument(customerId, documentId, documentTypeId);
            Guard.Against.DuplicateCustomerDocument(_customerDocuments, newCustomerDocument,
                nameof(newCustomerDocument));
            _customerDocuments.Add(newCustomerDocument);
            var customerDocumentAddedEvent = new CustomerDocumentCreatedEvent(newCustomerDocument, "Mongo-History");
            Events.Add(customerDocumentAddedEvent);
        }

        public void DeleteCustomerDocument(Guid customerId, Guid documentId)
        {
            Guard.Against.NullOrEmpty(customerId, nameof(customerId));
            Guard.Against.NullOrEmpty(documentId, nameof(documentId));

            var customerDocumentToDelete = _customerDocuments
                .Where(cd1 => cd1.CustomerId == customerId)
                .Where(cd2 => cd2.DocumentId == documentId)
                .FirstOrDefault();

            if (customerDocumentToDelete != null)
            {
                _customerDocuments.Remove(customerDocumentToDelete);
                var customerDocumentDeletedEvent =
                    new CustomerDocumentDeletedEvent(customerDocumentToDelete, "Mongo-History");
                Events.Add(customerDocumentDeletedEvent);
            }
        }

        public void AddNewCustomerEmailAddress(Guid customerId, Guid emailAddressId, Guid emailAddressTypeId)
        {
            Guard.Against.NullOrEmpty(customerId, nameof(customerId));
            Guard.Against.NullOrEmpty(emailAddressId, nameof(emailAddressId));
            Guard.Against.NullOrEmpty(emailAddressTypeId, nameof(emailAddressTypeId));

            var newCustomerEmailAddress = new CustomerEmailAddress(customerId, emailAddressId, emailAddressTypeId);
            Guard.Against.DuplicateCustomerEmailAddress(_customerEmailAddresses, newCustomerEmailAddress,
                nameof(newCustomerEmailAddress));
            _customerEmailAddresses.Add(newCustomerEmailAddress);
            var customerEmailAddressAddedEvent =
                new CustomerEmailAddressCreatedEvent(newCustomerEmailAddress, "Mongo-History");
            Events.Add(customerEmailAddressAddedEvent);
        }

        public void DeleteCustomerEmailAddress(Guid customerId, Guid emailAddressId)
        {
            Guard.Against.NullOrEmpty(customerId, nameof(customerId));
            Guard.Against.NullOrEmpty(emailAddressId, nameof(emailAddressId));

            var customerEmailAddressToDelete = _customerEmailAddresses
                .Where(cea1 => cea1.CustomerId == customerId)
                .Where(cea2 => cea2.EmailAddressId == emailAddressId)
                .FirstOrDefault();

            if (customerEmailAddressToDelete != null)
            {
                _customerEmailAddresses.Remove(customerEmailAddressToDelete);
                var customerEmailAddressDeletedEvent =
                    new CustomerEmailAddressDeletedEvent(customerEmailAddressToDelete, "Mongo-History");
                Events.Add(customerEmailAddressDeletedEvent);
            }
        }

        public void AddNewCustomerFeedback(CustomerFeedback customerFeedback)
        {
            Guard.Against.Null(customerFeedback, nameof(customerFeedback));
            Guard.Against.NullOrEmpty(customerFeedback.FeedbackId, nameof(customerFeedback.FeedbackId));
            Guard.Against.DuplicateCustomerFeedback(_customerFeedbacks, customerFeedback, nameof(customerFeedback));
            _customerFeedbacks.Add(customerFeedback);
            var customerFeedbackAddedEvent = new CustomerFeedbackCreatedEvent(customerFeedback, "Mongo-History");
            Events.Add(customerFeedbackAddedEvent);
        }

        public void DeleteCustomerFeedback(CustomerFeedback customerFeedback)
        {
            Guard.Against.Null(customerFeedback, nameof(customerFeedback));
            var customerFeedbackToDelete = _customerFeedbacks
                .Where(cf => cf.FeedbackId == customerFeedback.FeedbackId)
                .FirstOrDefault();
            if (customerFeedbackToDelete != null)
            {
                _customerFeedbacks.Remove(customerFeedbackToDelete);
                var customerFeedbackDeletedEvent =
                    new CustomerFeedbackDeletedEvent(customerFeedbackToDelete, "Mongo-History");
                Events.Add(customerFeedbackDeletedEvent);
            }
        }

        public void AddNewCustomerPhoneNumber(Guid customerId, Guid phoneNumberId, Guid phoneNumberTypeId)
        {
            Guard.Against.NullOrEmpty(customerId, nameof(customerId));
            Guard.Against.NullOrEmpty(phoneNumberId, nameof(phoneNumberId));
            Guard.Against.NullOrEmpty(phoneNumberTypeId, nameof(phoneNumberTypeId));

            var newCustomerPhoneNumber = new CustomerPhoneNumber(customerId, phoneNumberId, phoneNumberTypeId);
            Guard.Against.DuplicateCustomerPhoneNumber(_customerPhoneNumbers, newCustomerPhoneNumber,
                nameof(newCustomerPhoneNumber));
            _customerPhoneNumbers.Add(newCustomerPhoneNumber);
            var customerPhoneNumberAddedEvent =
                new CustomerPhoneNumberCreatedEvent(newCustomerPhoneNumber, "Mongo-History");
            Events.Add(customerPhoneNumberAddedEvent);
        }

        public void DeleteCustomerPhoneNumber(Guid customerId, Guid phoneNumberId)
        {
            Guard.Against.NullOrEmpty(customerId, nameof(customerId));
            Guard.Against.NullOrEmpty(phoneNumberId, nameof(phoneNumberId));

            var customerPhoneNumberToDelete = _customerPhoneNumbers
                .Where(cpn1 => cpn1.CustomerId == customerId)
                .Where(cpn2 => cpn2.PhoneNumberId == phoneNumberId)
                .FirstOrDefault();

            if (customerPhoneNumberToDelete != null)
            {
                _customerPhoneNumbers.Remove(customerPhoneNumberToDelete);
                var customerPhoneNumberDeletedEvent =
                    new CustomerPhoneNumberDeletedEvent(customerPhoneNumberToDelete, "Mongo-History");
                Events.Add(customerPhoneNumberDeletedEvent);
            }
        }

        public void AddNewCustomerPurchase(CustomerPurchase customerPurchase)
        {
            Guard.Against.Null(customerPurchase, nameof(customerPurchase));
            Guard.Against.NullOrEmpty(customerPurchase.CustomerPurchaseId, nameof(customerPurchase.CustomerPurchaseId));
            Guard.Against.DuplicateCustomerPurchase(_customerPurchases, customerPurchase, nameof(customerPurchase));
            _customerPurchases.Add(customerPurchase);
            var customerPurchaseAddedEvent = new CustomerPurchaseCreatedEvent(customerPurchase, "Mongo-History");
            Events.Add(customerPurchaseAddedEvent);
        }

        public void DeleteCustomerPurchase(CustomerPurchase customerPurchase)
        {
            Guard.Against.Null(customerPurchase, nameof(customerPurchase));
            var customerPurchaseToDelete = _customerPurchases
                .Where(cp => cp.CustomerPurchaseId == customerPurchase.CustomerPurchaseId)
                .FirstOrDefault();
            if (customerPurchaseToDelete != null)
            {
                _customerPurchases.Remove(customerPurchaseToDelete);
                var customerPurchaseDeletedEvent =
                    new CustomerPurchaseDeletedEvent(customerPurchaseToDelete, "Mongo-History");
                Events.Add(customerPurchaseDeletedEvent);
            }
        }

        public void AddNewCustomerReview(CustomerReview customerReview)
        {
            Guard.Against.Null(customerReview, nameof(customerReview));
            Guard.Against.NullOrEmpty(customerReview.CustomerReviewId, nameof(customerReview.CustomerReviewId));
            Guard.Against.DuplicateCustomerReview(_customerReviews, customerReview, nameof(customerReview));
            _customerReviews.Add(customerReview);
            var customerReviewAddedEvent = new CustomerReviewCreatedEvent(customerReview, "Mongo-History");
            Events.Add(customerReviewAddedEvent);
        }

        public void DeleteCustomerReview(CustomerReview customerReview)
        {
            Guard.Against.Null(customerReview, nameof(customerReview));
            var customerReviewToDelete = _customerReviews
                .Where(cr => cr.CustomerReviewId == customerReview.CustomerReviewId)
                .FirstOrDefault();
            if (customerReviewToDelete != null)
            {
                _customerReviews.Remove(customerReviewToDelete);
                var customerReviewDeletedEvent =
                    new CustomerReviewDeletedEvent(customerReviewToDelete, "Mongo-History");
                Events.Add(customerReviewDeletedEvent);
            }
        }

        public void AddNewDiscountCodeRedemption(DateTime discountCodeRedemptionDate, Guid customerId,
            Guid discountCodeId)
        {
            Guard.Against.OutOfSQLDateRange(discountCodeRedemptionDate, nameof(discountCodeRedemptionDate));
            Guard.Against.NullOrEmpty(customerId, nameof(customerId));
            Guard.Against.NullOrEmpty(discountCodeId, nameof(discountCodeId));

            var newDiscountCodeRedemption =
                new DiscountCodeRedemption(customerId, discountCodeId, discountCodeRedemptionDate);
            Guard.Against.DuplicateDiscountCodeRedemption(_discountCodeRedemptions, newDiscountCodeRedemption,
                nameof(newDiscountCodeRedemption));
            _discountCodeRedemptions.Add(newDiscountCodeRedemption);
            var discountCodeRedemptionAddedEvent =
                new DiscountCodeRedemptionCreatedEvent(newDiscountCodeRedemption, "Mongo-History");
            Events.Add(discountCodeRedemptionAddedEvent);
        }

        public void DeleteDiscountCodeRedemption(DateTime discountCodeRedemptionDate, Guid customerId,
            Guid discountCodeId)
        {
            Guard.Against.OutOfSQLDateRange(discountCodeRedemptionDate, nameof(discountCodeRedemptionDate));
            Guard.Against.NullOrEmpty(customerId, nameof(customerId));
            Guard.Against.NullOrEmpty(discountCodeId, nameof(discountCodeId));

            var discountCodeRedemptionToDelete = _discountCodeRedemptions
                .Where(dcr1 => dcr1.DiscountCodeRedemptionDate == discountCodeRedemptionDate)
                .Where(dcr2 => dcr2.CustomerId == customerId)
                .Where(dcr3 => dcr3.DiscountCodeId == discountCodeId)
                .FirstOrDefault();

            if (discountCodeRedemptionToDelete != null)
            {
                _discountCodeRedemptions.Remove(discountCodeRedemptionToDelete);
                var discountCodeRedemptionDeletedEvent =
                    new DiscountCodeRedemptionDeletedEvent(discountCodeRedemptionToDelete, "Mongo-History");
                Events.Add(discountCodeRedemptionDeletedEvent);
            }
        }

        public void AddNewGiftCodeRedemption(GiftCodeRedemption giftCodeRedemption)
        {
            Guard.Against.Null(giftCodeRedemption, nameof(giftCodeRedemption));
            Guard.Against.NullOrEmpty(giftCodeRedemption.GiftCodeRedemptionId,
                nameof(giftCodeRedemption.GiftCodeRedemptionId));
            Guard.Against.DuplicateGiftCodeRedemption(_giftCodeRedemptions, giftCodeRedemption,
                nameof(giftCodeRedemption));
            _giftCodeRedemptions.Add(giftCodeRedemption);
            var giftCodeRedemptionAddedEvent = new GiftCodeRedemptionCreatedEvent(giftCodeRedemption, "Mongo-History");
            Events.Add(giftCodeRedemptionAddedEvent);
        }

        public void DeleteGiftCodeRedemption(GiftCodeRedemption giftCodeRedemption)
        {
            Guard.Against.Null(giftCodeRedemption, nameof(giftCodeRedemption));
            var giftCodeRedemptionToDelete = _giftCodeRedemptions
                .Where(gcr => gcr.GiftCodeRedemptionId == giftCodeRedemption.GiftCodeRedemptionId)
                .FirstOrDefault();
            if (giftCodeRedemptionToDelete != null)
            {
                _giftCodeRedemptions.Remove(giftCodeRedemptionToDelete);
                var giftCodeRedemptionDeletedEvent =
                    new GiftCodeRedemptionDeletedEvent(giftCodeRedemptionToDelete, "Mongo-History");
                Events.Add(giftCodeRedemptionDeletedEvent);
            }
        }

        public void AddNewMessage(Message message)
        {
            Guard.Against.Null(message, nameof(message));
            Guard.Against.NullOrEmpty(message.MessageId, nameof(message.MessageId));
            Guard.Against.DuplicateMessage(_messages, message, nameof(message));
            _messages.Add(message);
            var messageAddedEvent = new MessageCreatedEvent(message, "Mongo-History");
            Events.Add(messageAddedEvent);
        }

        public void DeleteMessage(Message message)
        {
            Guard.Against.Null(message, nameof(message));
            var messageToDelete = _messages
                .Where(m => m.MessageId == message.MessageId)
                .FirstOrDefault();
            if (messageToDelete != null)
            {
                _messages.Remove(messageToDelete);
                var messageDeletedEvent = new MessageDeletedEvent(messageToDelete, "Mongo-History");
                Events.Add(messageDeletedEvent);
            }
        }

        public void AddNewPrepaidPackageRedemption(PrepaidPackageRedemption prepaidPackageRedemption)
        {
            Guard.Against.Null(prepaidPackageRedemption, nameof(prepaidPackageRedemption));
            Guard.Against.NullOrEmpty(prepaidPackageRedemption.PrepaidPackageRedemptionId,
                nameof(prepaidPackageRedemption.PrepaidPackageRedemptionId));
            Guard.Against.DuplicatePrepaidPackageRedemption(_prepaidPackageRedemptions, prepaidPackageRedemption,
                nameof(prepaidPackageRedemption));
            _prepaidPackageRedemptions.Add(prepaidPackageRedemption);
            var prepaidPackageRedemptionAddedEvent =
                new PrepaidPackageRedemptionCreatedEvent(prepaidPackageRedemption, "Mongo-History");
            Events.Add(prepaidPackageRedemptionAddedEvent);
        }

        public void DeletePrepaidPackageRedemption(PrepaidPackageRedemption prepaidPackageRedemption)
        {
            Guard.Against.Null(prepaidPackageRedemption, nameof(prepaidPackageRedemption));
            var prepaidPackageRedemptionToDelete = _prepaidPackageRedemptions
                .Where(ppr => ppr.PrepaidPackageRedemptionId == prepaidPackageRedemption.PrepaidPackageRedemptionId)
                .FirstOrDefault();
            if (prepaidPackageRedemptionToDelete != null)
            {
                _prepaidPackageRedemptions.Remove(prepaidPackageRedemptionToDelete);
                var prepaidPackageRedemptionDeletedEvent =
                    new PrepaidPackageRedemptionDeletedEvent(prepaidPackageRedemptionToDelete, "Mongo-History");
                Events.Add(prepaidPackageRedemptionDeletedEvent);
            }
        }

        public void AddNewSerfinsaPayment(SerfinsaPayment serfinsaPayment)
        {
            Guard.Against.Null(serfinsaPayment, nameof(serfinsaPayment));
            Guard.Against.NullOrEmpty(serfinsaPayment.SerfinsaPaymentId, nameof(serfinsaPayment.SerfinsaPaymentId));
            Guard.Against.DuplicateSerfinsaPayment(_serfinsaPayments, serfinsaPayment, nameof(serfinsaPayment));
            _serfinsaPayments.Add(serfinsaPayment);
            var serfinsaPaymentAddedEvent = new SerfinsaPaymentCreatedEvent(serfinsaPayment, "Mongo-History");
            Events.Add(serfinsaPaymentAddedEvent);
        }

        public void DeleteSerfinsaPayment(SerfinsaPayment serfinsaPayment)
        {
            Guard.Against.Null(serfinsaPayment, nameof(serfinsaPayment));
            var serfinsaPaymentToDelete = _serfinsaPayments
                .Where(sp => sp.SerfinsaPaymentId == serfinsaPayment.SerfinsaPaymentId)
                .FirstOrDefault();
            if (serfinsaPaymentToDelete != null)
            {
                _serfinsaPayments.Remove(serfinsaPaymentToDelete);
                var serfinsaPaymentDeletedEvent =
                    new SerfinsaPaymentDeletedEvent(serfinsaPaymentToDelete, "Mongo-History");
                Events.Add(serfinsaPaymentDeletedEvent);
            }
        }

        public void AddNewUnansweredConversation(UnansweredConversation unansweredConversation)
        {
            Guard.Against.Null(unansweredConversation, nameof(unansweredConversation));
            Guard.Against.NullOrEmpty(unansweredConversation.UnansweredConversationId,
                nameof(unansweredConversation.UnansweredConversationId));
            Guard.Against.DuplicateUnansweredConversation(_unansweredConversations, unansweredConversation,
                nameof(unansweredConversation));
            _unansweredConversations.Add(unansweredConversation);
            var unansweredConversationAddedEvent =
                new UnansweredConversationCreatedEvent(unansweredConversation, "Mongo-History");
            Events.Add(unansweredConversationAddedEvent);
        }

        public void DeleteUnansweredConversation(UnansweredConversation unansweredConversation)
        {
            Guard.Against.Null(unansweredConversation, nameof(unansweredConversation));
            var unansweredConversationToDelete = _unansweredConversations
                .Where(uc => uc.UnansweredConversationId == unansweredConversation.UnansweredConversationId)
                .FirstOrDefault();
            if (unansweredConversationToDelete != null)
            {
                _unansweredConversations.Remove(unansweredConversationToDelete);
                var unansweredConversationDeletedEvent =
                    new UnansweredConversationDeletedEvent(unansweredConversationToDelete, "Mongo-History");
                Events.Add(unansweredConversationDeletedEvent);
            }
        }
    }
}