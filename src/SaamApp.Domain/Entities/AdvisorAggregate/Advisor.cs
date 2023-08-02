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
    public class Advisor : BaseEntityEv<Guid>, IAggregateRoot
    {
        private readonly List<AdvisorAddress> _advisorAddresses = new();

        private readonly List<AdvisorBank> _advisorBanks = new();

        private readonly List<AdvisorBankTransferInfo> _advisorBankTransferInfoes = new();

        private readonly List<AdvisorCustomer> _advisorCustomers = new();

        private readonly List<AdvisorDocument> _advisorDocuments = new();

        private readonly List<AdvisorEmailAddress> _advisorEmailAddresses = new();

        private readonly List<AdvisorIdentityDocument> _advisorIdentityDocuments = new();

        private readonly List<AdvisorLogin> _advisorLogins = new();

        private readonly List<AdvisorPayment> _advisorPayments = new();

        private readonly List<AdvisorPhoneNumber> _advisorPhoneNumbers = new();

        private readonly List<AdvisorRating> _advisorRatings = new();

        private readonly List<AppointmentSchedule> _appointmentSchedules = new();

        private readonly List<CustomerReview> _customerReviews = new();

        private readonly List<Message> _messages = new();

        private readonly List<RegionAreaAdvisorCategory> _regionAreaAdvisorCategories = new();

        private readonly List<TrainingProgress> _trainingProgresses = new();

        private readonly List<TrainingQuizHistory> _trainingQuizHistories = new();

        private Advisor() { } // EF required

        //[SetsRequiredMembers]
        public Advisor(Guid advisorId, Guid businessUnitId, Guid genderId, Guid paymentFrequencyId,
            Guid taxInformationId, string advisorFirstName, string advisorLastName, string? advisorNote,
            string advisorTitle, string advisorJsonResume, bool isNaturalPerson, DateTime createdAt, Guid createdBy,
            DateTime? updatedAt, Guid? updatedBy, bool? isDeleted, Guid tenantId)
        {
            AdvisorId = Guard.Against.NullOrEmpty(advisorId, nameof(advisorId));
            BusinessUnitId = Guard.Against.NullOrEmpty(businessUnitId, nameof(businessUnitId));
            GenderId = Guard.Against.NullOrEmpty(genderId, nameof(genderId));
            PaymentFrequencyId = Guard.Against.NullOrEmpty(paymentFrequencyId, nameof(paymentFrequencyId));
            TaxInformationId = Guard.Against.NullOrEmpty(taxInformationId, nameof(taxInformationId));
            AdvisorFirstName = Guard.Against.NullOrWhiteSpace(advisorFirstName, nameof(advisorFirstName));
            AdvisorLastName = Guard.Against.NullOrWhiteSpace(advisorLastName, nameof(advisorLastName));
            AdvisorNote = advisorNote;
            AdvisorTitle = Guard.Against.NullOrWhiteSpace(advisorTitle, nameof(advisorTitle));
            AdvisorJsonResume = Guard.Against.NullOrWhiteSpace(advisorJsonResume, nameof(advisorJsonResume));
            IsNaturalPerson = Guard.Against.Null(isNaturalPerson, nameof(isNaturalPerson));
            CreatedAt = Guard.Against.OutOfSQLDateRange(createdAt, nameof(createdAt));
            CreatedBy = Guard.Against.NullOrEmpty(createdBy, nameof(createdBy));
            UpdatedAt = updatedAt;
            UpdatedBy = updatedBy;
            IsDeleted = isDeleted;
            TenantId = Guard.Against.NullOrEmpty(tenantId, nameof(tenantId));
        }

        [Key] public Guid AdvisorId { get; private set; }

        public string AdvisorFirstName { get; private set; }

        public string AdvisorLastName { get; private set; }

        public string? AdvisorNote { get; private set; }

        public string AdvisorTitle { get; private set; }

        public string AdvisorJsonResume { get; private set; }

        public bool IsNaturalPerson { get; private set; }

        public DateTime CreatedAt { get; private set; }

        public Guid CreatedBy { get; private set; }

        public DateTime? UpdatedAt { get; private set; }

        public Guid? UpdatedBy { get; private set; }

        public bool? IsDeleted { get; private set; }

        public Guid TenantId { get; private set; }

        public virtual BusinessUnit BusinessUnit { get; private set; }

        public Guid BusinessUnitId { get; private set; }

        public virtual Gender Gender { get; private set; }

        public Guid GenderId { get; private set; }

        public virtual PaymentFrequency PaymentFrequency { get; private set; }

        public Guid PaymentFrequencyId { get; private set; }

        public virtual TaxInformation TaxInformation { get; private set; }

        public Guid TaxInformationId { get; private set; }
        public IEnumerable<AdvisorAddress> AdvisorAddresses => _advisorAddresses.AsReadOnly();
        public IEnumerable<AdvisorBank> AdvisorBanks => _advisorBanks.AsReadOnly();

        public IEnumerable<AdvisorBankTransferInfo> AdvisorBankTransferInfoes =>
            _advisorBankTransferInfoes.AsReadOnly();

        public IEnumerable<AdvisorCustomer> AdvisorCustomers => _advisorCustomers.AsReadOnly();
        public IEnumerable<AdvisorDocument> AdvisorDocuments => _advisorDocuments.AsReadOnly();
        public IEnumerable<AdvisorEmailAddress> AdvisorEmailAddresses => _advisorEmailAddresses.AsReadOnly();
        public IEnumerable<AdvisorIdentityDocument> AdvisorIdentityDocuments => _advisorIdentityDocuments.AsReadOnly();
        public IEnumerable<AdvisorLogin> AdvisorLogins => _advisorLogins.AsReadOnly();
        public IEnumerable<AdvisorPayment> AdvisorPayments => _advisorPayments.AsReadOnly();
        public IEnumerable<AdvisorPhoneNumber> AdvisorPhoneNumbers => _advisorPhoneNumbers.AsReadOnly();
        public IEnumerable<AdvisorRating> AdvisorRatings => _advisorRatings.AsReadOnly();
        public IEnumerable<AppointmentSchedule> AppointmentSchedules => _appointmentSchedules.AsReadOnly();
        public IEnumerable<CustomerReview> CustomerReviews => _customerReviews.AsReadOnly();
        public IEnumerable<Message> Messages => _messages.AsReadOnly();

        public IEnumerable<RegionAreaAdvisorCategory> RegionAreaAdvisorCategories =>
            _regionAreaAdvisorCategories.AsReadOnly();

        public IEnumerable<TrainingProgress> TrainingProgresses => _trainingProgresses.AsReadOnly();
        public IEnumerable<TrainingQuizHistory> TrainingQuizHistories => _trainingQuizHistories.AsReadOnly();

        public void SetAdvisorFirstName(string advisorFirstName)
        {
            AdvisorFirstName = Guard.Against.NullOrEmpty(advisorFirstName, nameof(advisorFirstName));
        }

        public void SetAdvisorLastName(string advisorLastName)
        {
            AdvisorLastName = Guard.Against.NullOrEmpty(advisorLastName, nameof(advisorLastName));
        }

        public void SetAdvisorNote(string advisorNote)
        {
            AdvisorNote = advisorNote;
        }

        public void SetAdvisorTitle(string advisorTitle)
        {
            AdvisorTitle = Guard.Against.NullOrEmpty(advisorTitle, nameof(advisorTitle));
        }

        public void SetAdvisorJsonResume(string advisorJsonResume)
        {
            AdvisorJsonResume = Guard.Against.NullOrEmpty(advisorJsonResume, nameof(advisorJsonResume));
        }

        public void UpdateBusinessUnitForAdvisor(Guid newBusinessUnitId)
        {
            Guard.Against.NullOrEmpty(newBusinessUnitId, nameof(newBusinessUnitId));
            if (newBusinessUnitId == BusinessUnitId)
            {
                return;
            }

            BusinessUnitId = newBusinessUnitId;
            var advisorUpdatedEvent = new AdvisorUpdatedEvent(this, "Mongo-History");
            Events.Add(advisorUpdatedEvent);
        }


        public void UpdateGenderForAdvisor(Guid newGenderId)
        {
            Guard.Against.NullOrEmpty(newGenderId, nameof(newGenderId));
            if (newGenderId == GenderId)
            {
                return;
            }

            GenderId = newGenderId;
            var advisorUpdatedEvent = new AdvisorUpdatedEvent(this, "Mongo-History");
            Events.Add(advisorUpdatedEvent);
        }


        public void UpdatePaymentFrequencyForAdvisor(Guid newPaymentFrequencyId)
        {
            Guard.Against.NullOrEmpty(newPaymentFrequencyId, nameof(newPaymentFrequencyId));
            if (newPaymentFrequencyId == PaymentFrequencyId)
            {
                return;
            }

            PaymentFrequencyId = newPaymentFrequencyId;
            var advisorUpdatedEvent = new AdvisorUpdatedEvent(this, "Mongo-History");
            Events.Add(advisorUpdatedEvent);
        }


        public void UpdateTaxInformationForAdvisor(Guid newTaxInformationId)
        {
            Guard.Against.NullOrEmpty(newTaxInformationId, nameof(newTaxInformationId));
            if (newTaxInformationId == TaxInformationId)
            {
                return;
            }

            TaxInformationId = newTaxInformationId;
            var advisorUpdatedEvent = new AdvisorUpdatedEvent(this, "Mongo-History");
            Events.Add(advisorUpdatedEvent);
        }


        public void AddNewAdvisorAddress(Guid addressId, Guid addressTypeId, Guid advisorId)
        {
            Guard.Against.NullOrEmpty(addressId, nameof(addressId));
            Guard.Against.NullOrEmpty(addressTypeId, nameof(addressTypeId));
            Guard.Against.NullOrEmpty(advisorId, nameof(advisorId));

            var newAdvisorAddress = new AdvisorAddress(addressId, addressTypeId, advisorId);
            Guard.Against.DuplicateAdvisorAddress(_advisorAddresses, newAdvisorAddress, nameof(newAdvisorAddress));
            _advisorAddresses.Add(newAdvisorAddress);
            var advisorAddressAddedEvent = new AdvisorAddressCreatedEvent(newAdvisorAddress, "Mongo-History");
            Events.Add(advisorAddressAddedEvent);
        }

        public void DeleteAdvisorAddress(Guid addressId, Guid advisorId)
        {
            Guard.Against.NullOrEmpty(addressId, nameof(addressId));
            Guard.Against.NullOrEmpty(advisorId, nameof(advisorId));

            var advisorAddressToDelete = _advisorAddresses
                .Where(aa1 => aa1.AddressId == addressId)
                .Where(aa3 => aa3.AdvisorId == advisorId)
                .FirstOrDefault();

            if (advisorAddressToDelete != null)
            {
                _advisorAddresses.Remove(advisorAddressToDelete);
                var advisorAddressDeletedEvent =
                    new AdvisorAddressDeletedEvent(advisorAddressToDelete, "Mongo-History");
                Events.Add(advisorAddressDeletedEvent);
            }
        }

        public void AddNewAdvisorBank(bool isDefault, Guid advisorId, Guid bankAccountId)
        {
            Guard.Against.Null(isDefault, nameof(isDefault));
            Guard.Against.NullOrEmpty(advisorId, nameof(advisorId));
            Guard.Against.NullOrEmpty(bankAccountId, nameof(bankAccountId));

            var newAdvisorBank = new AdvisorBank(advisorId, bankAccountId, isDefault);
            Guard.Against.DuplicateAdvisorBank(_advisorBanks, newAdvisorBank, nameof(newAdvisorBank));
            _advisorBanks.Add(newAdvisorBank);
            var advisorBankAddedEvent = new AdvisorBankCreatedEvent(newAdvisorBank, "Mongo-History");
            Events.Add(advisorBankAddedEvent);
        }

        public void DeleteAdvisorBank(bool isDefault, Guid advisorId, Guid bankAccountId)
        {
            Guard.Against.Null(isDefault, nameof(isDefault));
            Guard.Against.NullOrEmpty(advisorId, nameof(advisorId));
            Guard.Against.NullOrEmpty(bankAccountId, nameof(bankAccountId));

            var advisorBankToDelete = _advisorBanks
                .Where(ab1 => ab1.IsDefault == isDefault)
                .Where(ab2 => ab2.AdvisorId == advisorId)
                .Where(ab3 => ab3.BankAccountId == bankAccountId)
                .FirstOrDefault();

            if (advisorBankToDelete != null)
            {
                _advisorBanks.Remove(advisorBankToDelete);
                var advisorBankDeletedEvent = new AdvisorBankDeletedEvent(advisorBankToDelete, "Mongo-History");
                Events.Add(advisorBankDeletedEvent);
            }
        }

        public void AddNewAdvisorBankTransferInfo(AdvisorBankTransferInfo advisorBankTransferInfo)
        {
            Guard.Against.Null(advisorBankTransferInfo, nameof(advisorBankTransferInfo));
            Guard.Against.NullOrEmpty(advisorBankTransferInfo.AdvisorBankTransferInfoId,
                nameof(advisorBankTransferInfo.AdvisorBankTransferInfoId));
            Guard.Against.DuplicateAdvisorBankTransferInfo(_advisorBankTransferInfoes, advisorBankTransferInfo,
                nameof(advisorBankTransferInfo));
            _advisorBankTransferInfoes.Add(advisorBankTransferInfo);
            var advisorBankTransferInfoAddedEvent =
                new AdvisorBankTransferInfoCreatedEvent(advisorBankTransferInfo, "Mongo-History");
            Events.Add(advisorBankTransferInfoAddedEvent);
        }

        public void DeleteAdvisorBankTransferInfo(AdvisorBankTransferInfo advisorBankTransferInfo)
        {
            Guard.Against.Null(advisorBankTransferInfo, nameof(advisorBankTransferInfo));
            var advisorBankTransferInfoToDelete = _advisorBankTransferInfoes
                .Where(abti => abti.AdvisorBankTransferInfoId == advisorBankTransferInfo.AdvisorBankTransferInfoId)
                .FirstOrDefault();
            if (advisorBankTransferInfoToDelete != null)
            {
                _advisorBankTransferInfoes.Remove(advisorBankTransferInfoToDelete);
                var advisorBankTransferInfoDeletedEvent =
                    new AdvisorBankTransferInfoDeletedEvent(advisorBankTransferInfoToDelete, "Mongo-History");
                Events.Add(advisorBankTransferInfoDeletedEvent);
            }
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

        public void AddNewAdvisorDocument(Guid advisorId, Guid documentId, Guid documentTypeId)
        {
            Guard.Against.NullOrEmpty(advisorId, nameof(advisorId));
            Guard.Against.NullOrEmpty(documentId, nameof(documentId));
            Guard.Against.NullOrEmpty(documentTypeId, nameof(documentTypeId));

            var newAdvisorDocument = new AdvisorDocument(advisorId, documentId, documentTypeId);
            Guard.Against.DuplicateAdvisorDocument(_advisorDocuments, newAdvisorDocument, nameof(newAdvisorDocument));
            _advisorDocuments.Add(newAdvisorDocument);
            var advisorDocumentAddedEvent = new AdvisorDocumentCreatedEvent(newAdvisorDocument, "Mongo-History");
            Events.Add(advisorDocumentAddedEvent);
        }

        public void DeleteAdvisorDocument(Guid advisorId, Guid documentId)
        {
            Guard.Against.NullOrEmpty(advisorId, nameof(advisorId));
            Guard.Against.NullOrEmpty(documentId, nameof(documentId));

            var advisorDocumentToDelete = _advisorDocuments
                .Where(ad1 => ad1.AdvisorId == advisorId)
                .Where(ad2 => ad2.DocumentId == documentId)
                .FirstOrDefault();

            if (advisorDocumentToDelete != null)
            {
                _advisorDocuments.Remove(advisorDocumentToDelete);
                var advisorDocumentDeletedEvent =
                    new AdvisorDocumentDeletedEvent(advisorDocumentToDelete, "Mongo-History");
                Events.Add(advisorDocumentDeletedEvent);
            }
        }

        public void AddNewAdvisorEmailAddress(Guid advisorId, Guid emailAddressId, Guid emailAddressTypeId)
        {
            Guard.Against.NullOrEmpty(advisorId, nameof(advisorId));
            Guard.Against.NullOrEmpty(emailAddressId, nameof(emailAddressId));
            Guard.Against.NullOrEmpty(emailAddressTypeId, nameof(emailAddressTypeId));

            var newAdvisorEmailAddress = new AdvisorEmailAddress(advisorId, emailAddressId, emailAddressTypeId);
            Guard.Against.DuplicateAdvisorEmailAddress(_advisorEmailAddresses, newAdvisorEmailAddress,
                nameof(newAdvisorEmailAddress));
            _advisorEmailAddresses.Add(newAdvisorEmailAddress);
            var advisorEmailAddressAddedEvent =
                new AdvisorEmailAddressCreatedEvent(newAdvisorEmailAddress, "Mongo-History");
            Events.Add(advisorEmailAddressAddedEvent);
        }

        public void DeleteAdvisorEmailAddress(Guid advisorId, Guid emailAddressId)
        {
            Guard.Against.NullOrEmpty(advisorId, nameof(advisorId));
            Guard.Against.NullOrEmpty(emailAddressId, nameof(emailAddressId));

            var advisorEmailAddressToDelete = _advisorEmailAddresses
                .Where(aea1 => aea1.AdvisorId == advisorId)
                .Where(aea2 => aea2.EmailAddressId == emailAddressId)
                .FirstOrDefault();

            if (advisorEmailAddressToDelete != null)
            {
                _advisorEmailAddresses.Remove(advisorEmailAddressToDelete);
                var advisorEmailAddressDeletedEvent =
                    new AdvisorEmailAddressDeletedEvent(advisorEmailAddressToDelete, "Mongo-History");
                Events.Add(advisorEmailAddressDeletedEvent);
            }
        }

        public void AddNewAdvisorIdentityDocument(Guid advisorId, Guid documentId, Guid documentTypeId,
            Guid identityDocumentId)
        {
            Guard.Against.NullOrEmpty(advisorId, nameof(advisorId));
            Guard.Against.NullOrEmpty(documentId, nameof(documentId));
            Guard.Against.NullOrEmpty(documentTypeId, nameof(documentTypeId));
            Guard.Against.NullOrEmpty(identityDocumentId, nameof(identityDocumentId));

            var newAdvisorIdentityDocument =
                new AdvisorIdentityDocument(advisorId, documentId, documentTypeId, identityDocumentId);
            Guard.Against.DuplicateAdvisorIdentityDocument(_advisorIdentityDocuments, newAdvisorIdentityDocument,
                nameof(newAdvisorIdentityDocument));
            _advisorIdentityDocuments.Add(newAdvisorIdentityDocument);
            var advisorIdentityDocumentAddedEvent =
                new AdvisorIdentityDocumentCreatedEvent(newAdvisorIdentityDocument, "Mongo-History");
            Events.Add(advisorIdentityDocumentAddedEvent);
        }

        public void DeleteAdvisorIdentityDocument(Guid advisorId, Guid documentId, Guid identityDocumentId)
        {
            Guard.Against.NullOrEmpty(advisorId, nameof(advisorId));
            Guard.Against.NullOrEmpty(documentId, nameof(documentId));
            Guard.Against.NullOrEmpty(identityDocumentId, nameof(identityDocumentId));

            var advisorIdentityDocumentToDelete = _advisorIdentityDocuments
                .Where(aid1 => aid1.AdvisorId == advisorId)
                .Where(aid2 => aid2.DocumentId == documentId)
                .Where(aid4 => aid4.IdentityDocumentId == identityDocumentId)
                .FirstOrDefault();

            if (advisorIdentityDocumentToDelete != null)
            {
                _advisorIdentityDocuments.Remove(advisorIdentityDocumentToDelete);
                var advisorIdentityDocumentDeletedEvent =
                    new AdvisorIdentityDocumentDeletedEvent(advisorIdentityDocumentToDelete, "Mongo-History");
                Events.Add(advisorIdentityDocumentDeletedEvent);
            }
        }

        public void AddNewAdvisorLogin(AdvisorLogin advisorLogin)
        {
            Guard.Against.Null(advisorLogin, nameof(advisorLogin));
            Guard.Against.NullOrEmpty(advisorLogin.AdvisorLoginId, nameof(advisorLogin.AdvisorLoginId));
            Guard.Against.DuplicateAdvisorLogin(_advisorLogins, advisorLogin, nameof(advisorLogin));
            _advisorLogins.Add(advisorLogin);
            var advisorLoginAddedEvent = new AdvisorLoginCreatedEvent(advisorLogin, "Mongo-History");
            Events.Add(advisorLoginAddedEvent);
        }

        public void DeleteAdvisorLogin(AdvisorLogin advisorLogin)
        {
            Guard.Against.Null(advisorLogin, nameof(advisorLogin));
            var advisorLoginToDelete = _advisorLogins
                .Where(al => al.AdvisorLoginId == advisorLogin.AdvisorLoginId)
                .FirstOrDefault();
            if (advisorLoginToDelete != null)
            {
                _advisorLogins.Remove(advisorLoginToDelete);
                var advisorLoginDeletedEvent = new AdvisorLoginDeletedEvent(advisorLoginToDelete, "Mongo-History");
                Events.Add(advisorLoginDeletedEvent);
            }
        }

        public void AddNewAdvisorPayment(string advisorPaymentDescription, decimal advisorPaymentsAmount,
            DateTime createdAt, Guid createdBy, DateTime? updatedAt, Guid? updatedBy, bool? isDeleted, Guid advisorId,
            Guid bankAccountId, Guid paymentMethodId)
        {
            Guard.Against.NullOrWhiteSpace(advisorPaymentDescription, nameof(advisorPaymentDescription));
            Guard.Against.Negative(advisorPaymentsAmount, nameof(advisorPaymentsAmount));
            Guard.Against.OutOfSQLDateRange(createdAt, nameof(createdAt));
            Guard.Against.NullOrEmpty(createdBy, nameof(createdBy));
            Guard.Against.NullOrEmpty(advisorId, nameof(advisorId));
            Guard.Against.NullOrEmpty(bankAccountId, nameof(bankAccountId));
            Guard.Against.NullOrEmpty(paymentMethodId, nameof(paymentMethodId));

            var newAdvisorPayment = new AdvisorPayment(advisorId, bankAccountId, paymentMethodId,
                advisorPaymentDescription, advisorPaymentsAmount, createdAt, createdBy, updatedAt, updatedBy,
                isDeleted);
            Guard.Against.DuplicateAdvisorPayment(_advisorPayments, newAdvisorPayment, nameof(newAdvisorPayment));
            _advisorPayments.Add(newAdvisorPayment);
            var advisorPaymentAddedEvent = new AdvisorPaymentCreatedEvent(newAdvisorPayment, "Mongo-History");
            Events.Add(advisorPaymentAddedEvent);
        }

        public void DeleteAdvisorPayment(string advisorPaymentDescription, decimal advisorPaymentsAmount,
            DateTime createdAt, Guid createdBy, DateTime updatedAt, Guid updatedBy, bool isDeleted, Guid advisorId,
            Guid bankAccountId, Guid paymentMethodId)
        {
            Guard.Against.NullOrWhiteSpace(advisorPaymentDescription, nameof(advisorPaymentDescription));
            Guard.Against.Negative(advisorPaymentsAmount, nameof(advisorPaymentsAmount));
            Guard.Against.OutOfSQLDateRange(createdAt, nameof(createdAt));
            Guard.Against.NullOrEmpty(createdBy, nameof(createdBy));
            Guard.Against.OutOfSQLDateRange(updatedAt, nameof(updatedAt));
            Guard.Against.NullOrEmpty(updatedBy, nameof(updatedBy));
            Guard.Against.Null(isDeleted, nameof(isDeleted));
            Guard.Against.NullOrEmpty(advisorId, nameof(advisorId));
            Guard.Against.NullOrEmpty(bankAccountId, nameof(bankAccountId));
            Guard.Against.NullOrEmpty(paymentMethodId, nameof(paymentMethodId));

            var advisorPaymentToDelete = _advisorPayments
                .Where(ap1 => ap1.AdvisorPaymentDescription == advisorPaymentDescription)
                .Where(ap2 => ap2.AdvisorPaymentsAmount == advisorPaymentsAmount)
                .Where(ap3 => ap3.CreatedAt == createdAt)
                .Where(ap4 => ap4.CreatedBy == createdBy)
                .Where(ap5 => ap5.UpdatedAt == updatedAt)
                .Where(ap6 => ap6.UpdatedBy == updatedBy)
                .Where(ap7 => ap7.IsDeleted == isDeleted)
                .Where(ap8 => ap8.AdvisorId == advisorId)
                .Where(ap9 => ap9.BankAccountId == bankAccountId)
                .Where(ap10 => ap10.PaymentMethodId == paymentMethodId)
                .FirstOrDefault();

            if (advisorPaymentToDelete != null)
            {
                _advisorPayments.Remove(advisorPaymentToDelete);
                var advisorPaymentDeletedEvent =
                    new AdvisorPaymentDeletedEvent(advisorPaymentToDelete, "Mongo-History");
                Events.Add(advisorPaymentDeletedEvent);
            }
        }

        public void AddNewAdvisorPhoneNumber(Guid advisorId, Guid phoneNumberId, Guid phoneNumberTypeId)
        {
            Guard.Against.NullOrEmpty(advisorId, nameof(advisorId));
            Guard.Against.NullOrEmpty(phoneNumberId, nameof(phoneNumberId));
            Guard.Against.NullOrEmpty(phoneNumberTypeId, nameof(phoneNumberTypeId));

            var newAdvisorPhoneNumber = new AdvisorPhoneNumber(advisorId, phoneNumberId, phoneNumberTypeId);
            Guard.Against.DuplicateAdvisorPhoneNumber(_advisorPhoneNumbers, newAdvisorPhoneNumber,
                nameof(newAdvisorPhoneNumber));
            _advisorPhoneNumbers.Add(newAdvisorPhoneNumber);
            var advisorPhoneNumberAddedEvent =
                new AdvisorPhoneNumberCreatedEvent(newAdvisorPhoneNumber, "Mongo-History");
            Events.Add(advisorPhoneNumberAddedEvent);
        }

        public void DeleteAdvisorPhoneNumber(Guid advisorId, Guid phoneNumberId)
        {
            Guard.Against.NullOrEmpty(advisorId, nameof(advisorId));
            Guard.Against.NullOrEmpty(phoneNumberId, nameof(phoneNumberId));

            var advisorPhoneNumberToDelete = _advisorPhoneNumbers
                .Where(apn1 => apn1.AdvisorId == advisorId)
                .Where(apn2 => apn2.PhoneNumberId == phoneNumberId)
                .FirstOrDefault();

            if (advisorPhoneNumberToDelete != null)
            {
                _advisorPhoneNumbers.Remove(advisorPhoneNumberToDelete);
                var advisorPhoneNumberDeletedEvent =
                    new AdvisorPhoneNumberDeletedEvent(advisorPhoneNumberToDelete, "Mongo-History");
                Events.Add(advisorPhoneNumberDeletedEvent);
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

        public void AddNewRegionAreaAdvisorCategory(RegionAreaAdvisorCategory regionAreaAdvisorCategory)
        {
            Guard.Against.Null(regionAreaAdvisorCategory, nameof(regionAreaAdvisorCategory));
            Guard.Against.NullOrEmpty(regionAreaAdvisorCategory.RegionAreaAdvisorCategoryId,
                nameof(regionAreaAdvisorCategory.RegionAreaAdvisorCategoryId));
            Guard.Against.DuplicateRegionAreaAdvisorCategory(_regionAreaAdvisorCategories, regionAreaAdvisorCategory,
                nameof(regionAreaAdvisorCategory));
            _regionAreaAdvisorCategories.Add(regionAreaAdvisorCategory);
            var regionAreaAdvisorCategoryAddedEvent =
                new RegionAreaAdvisorCategoryCreatedEvent(regionAreaAdvisorCategory, "Mongo-History");
            Events.Add(regionAreaAdvisorCategoryAddedEvent);
        }

        public void DeleteRegionAreaAdvisorCategory(RegionAreaAdvisorCategory regionAreaAdvisorCategory)
        {
            Guard.Against.Null(regionAreaAdvisorCategory, nameof(regionAreaAdvisorCategory));
            var regionAreaAdvisorCategoryToDelete = _regionAreaAdvisorCategories
                .Where(raac =>
                    raac.RegionAreaAdvisorCategoryId == regionAreaAdvisorCategory.RegionAreaAdvisorCategoryId)
                .FirstOrDefault();
            if (regionAreaAdvisorCategoryToDelete != null)
            {
                _regionAreaAdvisorCategories.Remove(regionAreaAdvisorCategoryToDelete);
                var regionAreaAdvisorCategoryDeletedEvent =
                    new RegionAreaAdvisorCategoryDeletedEvent(regionAreaAdvisorCategoryToDelete, "Mongo-History");
                Events.Add(regionAreaAdvisorCategoryDeletedEvent);
            }
        }

        public void AddNewTrainingProgress(TrainingProgress trainingProgress)
        {
            Guard.Against.Null(trainingProgress, nameof(trainingProgress));
            Guard.Against.NullOrEmpty(trainingProgress.TrainingProgressId, nameof(trainingProgress.TrainingProgressId));
            Guard.Against.DuplicateTrainingProgress(_trainingProgresses, trainingProgress, nameof(trainingProgress));
            _trainingProgresses.Add(trainingProgress);
            var trainingProgressAddedEvent = new TrainingProgressCreatedEvent(trainingProgress, "Mongo-History");
            Events.Add(trainingProgressAddedEvent);
        }

        public void DeleteTrainingProgress(TrainingProgress trainingProgress)
        {
            Guard.Against.Null(trainingProgress, nameof(trainingProgress));
            var trainingProgressToDelete = _trainingProgresses
                .Where(tp => tp.TrainingProgressId == trainingProgress.TrainingProgressId)
                .FirstOrDefault();
            if (trainingProgressToDelete != null)
            {
                _trainingProgresses.Remove(trainingProgressToDelete);
                var trainingProgressDeletedEvent =
                    new TrainingProgressDeletedEvent(trainingProgressToDelete, "Mongo-History");
                Events.Add(trainingProgressDeletedEvent);
            }
        }

        public void AddNewTrainingQuizHistory(TrainingQuizHistory trainingQuizHistory)
        {
            Guard.Against.Null(trainingQuizHistory, nameof(trainingQuizHistory));
            Guard.Against.NullOrEmpty(trainingQuizHistory.TrainingQuizHistoryId,
                nameof(trainingQuizHistory.TrainingQuizHistoryId));
            Guard.Against.DuplicateTrainingQuizHistory(_trainingQuizHistories, trainingQuizHistory,
                nameof(trainingQuizHistory));
            _trainingQuizHistories.Add(trainingQuizHistory);
            var trainingQuizHistoryAddedEvent =
                new TrainingQuizHistoryCreatedEvent(trainingQuizHistory, "Mongo-History");
            Events.Add(trainingQuizHistoryAddedEvent);
        }

        public void DeleteTrainingQuizHistory(TrainingQuizHistory trainingQuizHistory)
        {
            Guard.Against.Null(trainingQuizHistory, nameof(trainingQuizHistory));
            var trainingQuizHistoryToDelete = _trainingQuizHistories
                .Where(tqh => tqh.TrainingQuizHistoryId == trainingQuizHistory.TrainingQuizHistoryId)
                .FirstOrDefault();
            if (trainingQuizHistoryToDelete != null)
            {
                _trainingQuizHistories.Remove(trainingQuizHistoryToDelete);
                var trainingQuizHistoryDeletedEvent =
                    new TrainingQuizHistoryDeletedEvent(trainingQuizHistoryToDelete, "Mongo-History");
                Events.Add(trainingQuizHistoryDeletedEvent);
            }
        }
    }
}