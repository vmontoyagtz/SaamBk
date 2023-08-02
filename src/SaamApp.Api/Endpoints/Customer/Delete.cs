using System;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.Customer;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.CustomerEndpoints
{
    /// <summary>
    ///     This is a delete endpoint for a customer in an application using the DDD (Domain-Driven Design)
    ///     pattern and the CQRS (Command and Query Responsibility Segregation) pattern.
    ///     The endpoint uses the DeleteCustomerRequest model to delete a customer from the database.
    ///     It also uses several repositories to delete related data, such as addresses, email addresses,
    ///     phone numbers, and invoices, for the customer before deleting the customer itself.
    ///     The endpoint also uses AutoMapper to map between the Customer entity and the DeleteCustomerRequest model.
    ///     The endpoint returns a DeleteCustomerResponse object indicating the status of the deletion.
    /// </summary>
    public class Delete : EndpointBaseAsync.WithRequest<DeleteCustomerRequest>.WithActionResult<
        DeleteCustomerResponse>
    {
        private readonly IRepository<AdvisorCustomer> _advisorCustomerRepository;
        private readonly IRepository<AdvisorRating> _advisorRatingRepository;
        private readonly IRepository<AiFeedback> _aiFeedbackRepository;
        private readonly IRepository<AiInteraction> _aiInteractionRepository;
        private readonly IRepository<AiSession> _aiSessionRepository;
        private readonly IRepository<AppointmentSchedule> _appointmentScheduleRepository;
        private readonly IRepository<CustomerAccount> _customerAccountRepository;
        private readonly IRepository<CustomerAddress> _customerAddressRepository;
        private readonly IRepository<CustomerAiHistory> _customerAiHistoryRepository;
        private readonly IRepository<CustomerDocument> _customerDocumentRepository;
        private readonly IRepository<CustomerEmailAddress> _customerEmailAddressRepository;
        private readonly IRepository<CustomerFeedback> _customerFeedbackRepository;
        private readonly IRepository<CustomerPhoneNumber> _customerPhoneNumberRepository;
        private readonly IRepository<CustomerPurchase> _customerPurchaseRepository;
        private readonly IRepository<Customer> _customerReadRepository;
        private readonly IRepository<CustomerReview> _customerReviewRepository;
        private readonly IRepository<DiscountCodeRedemption> _discountCodeRedemptionRepository;
        private readonly IRepository<GiftCodeRedemption> _giftCodeRedemptionRepository;

        private readonly IMapper _mapper;

        //  private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<Message> _messageRepository;
        private readonly IRepository<PrepaidPackageRedemption> _prepaidPackageRedemptionRepository;
        private readonly IRepository<Customer> _repository;
        private readonly IRepository<SerfinsaPayment> _serfinsaPaymentRepository;
        private readonly IRepository<UnansweredConversation> _unansweredConversationRepository;

        public Delete(IRepository<Customer> CustomerRepository, IRepository<Customer> CustomerReadRepository,
            IRepository<AdvisorCustomer> advisorCustomerRepository,
            IRepository<AdvisorRating> advisorRatingRepository,
            IRepository<AiFeedback> aiFeedbackRepository,
            IRepository<AiInteraction> aiInteractionRepository,
            IRepository<AiSession> aiSessionRepository,
            IRepository<AppointmentSchedule> appointmentScheduleRepository,
            IRepository<CustomerAccount> customerAccountRepository,
            IRepository<CustomerAddress> customerAddressRepository,
            IRepository<CustomerAiHistory> customerAiHistoryRepository,
            IRepository<CustomerDocument> customerDocumentRepository,
            IRepository<CustomerEmailAddress> customerEmailAddressRepository,
            IRepository<CustomerFeedback> customerFeedbackRepository,
            IRepository<CustomerPhoneNumber> customerPhoneNumberRepository,
            IRepository<CustomerPurchase> customerPurchaseRepository,
            IRepository<CustomerReview> customerReviewRepository,
            IRepository<DiscountCodeRedemption> discountCodeRedemptionRepository,
            IRepository<GiftCodeRedemption> giftCodeRedemptionRepository,
            IRepository<Message> messageRepository,
            IRepository<PrepaidPackageRedemption> prepaidPackageRedemptionRepository,
            IRepository<SerfinsaPayment> serfinsaPaymentRepository,
            IRepository<UnansweredConversation> unansweredConversationRepository,
            //  IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = CustomerRepository;
            _customerReadRepository = CustomerReadRepository;
            _advisorCustomerRepository = advisorCustomerRepository;
            _advisorRatingRepository = advisorRatingRepository;
            _aiFeedbackRepository = aiFeedbackRepository;
            _aiInteractionRepository = aiInteractionRepository;
            _aiSessionRepository = aiSessionRepository;
            _appointmentScheduleRepository = appointmentScheduleRepository;
            _customerAccountRepository = customerAccountRepository;
            _customerAddressRepository = customerAddressRepository;
            _customerAiHistoryRepository = customerAiHistoryRepository;
            _customerDocumentRepository = customerDocumentRepository;
            _customerEmailAddressRepository = customerEmailAddressRepository;
            _customerFeedbackRepository = customerFeedbackRepository;
            _customerPhoneNumberRepository = customerPhoneNumberRepository;
            _customerPurchaseRepository = customerPurchaseRepository;
            _customerReviewRepository = customerReviewRepository;
            _discountCodeRedemptionRepository = discountCodeRedemptionRepository;
            _giftCodeRedemptionRepository = giftCodeRedemptionRepository;
            _messageRepository = messageRepository;
            _prepaidPackageRedemptionRepository = prepaidPackageRedemptionRepository;
            _serfinsaPaymentRepository = serfinsaPaymentRepository;
            _unansweredConversationRepository = unansweredConversationRepository;
            _mapper = mapper;
            // _messagePublisher = messagePublisher;
        }

        [HttpDelete("api/customers/{CustomerId}")]
        [SwaggerOperation(
            Summary = "Deletes an Customer",
            Description = "Deletes an Customer",
            OperationId = "customers.delete",
            Tags = new[] { "CustomerEndpoints" })
        ]
        public override async Task<ActionResult<DeleteCustomerResponse>> HandleAsync(
            [FromRoute] DeleteCustomerRequest request, CancellationToken cancellationToken)
        {
            var response = new DeleteCustomerResponse(request.CorrelationId());

            var customer = await _customerReadRepository.GetByIdAsync(request.CustomerId);

            if (customer == null)
            {
                return NotFound();
            }

            var advisorCustomerSpec = new GetAdvisorCustomerWithCustomerKeySpec(customer.CustomerId);
            var advisorCustomers = await _advisorCustomerRepository.ListAsync(advisorCustomerSpec);

            foreach (var ac in advisorCustomers)
            {
                customer.DeleteAdvisorCustomer(ac.AdvisorId, customer.CustomerId);
            }

            var advisorRatingSpec = new GetAdvisorRatingWithCustomerKeySpec(customer.CustomerId);
            var advisorRatings = await _advisorRatingRepository.ListAsync(advisorRatingSpec);
            foreach (var ar in advisorRatings)
            {
                customer.DeleteAdvisorRating(ar.AdvisorRatingFeedback, ar.AdvisorRatingRate, ar.AdvisorRatingDate,
                    ar.AdvisorId, ar.ConversationId, customer.CustomerId, ar.RatingReasonId);
            }

            var aiFeedbackSpec = new GetAiFeedbackWithCustomerKeySpec(customer.CustomerId);
            var aiFeedbacks = await _aiFeedbackRepository.ListAsync(aiFeedbackSpec);

            foreach (var af in aiFeedbacks)
            {
                customer.DeleteAiFeedback(af);
            }

            var aiInteractionSpec = new GetAiInteractionWithCustomerKeySpec(customer.CustomerId);
            var aiInteractions = await _aiInteractionRepository.ListAsync(aiInteractionSpec);

            foreach (var ai in aiInteractions)
            {
                customer.DeleteAiInteraction(ai);
            }

            var aiSessionSpec = new GetAiSessionWithCustomerKeySpec(customer.CustomerId);
            var aiSessions = await _aiSessionRepository.ListAsync(aiSessionSpec);

            foreach (var as1 in aiSessions)
            {
                customer.DeleteAiSession(as1);
            }

            var appointmentScheduleSpec = new GetAppointmentScheduleWithCustomerKeySpec(customer.CustomerId);
            var appointmentSchedules = await _appointmentScheduleRepository.ListAsync(appointmentScheduleSpec);

            foreach (var asf in appointmentSchedules)
            {
                customer.DeleteAppointmentSchedule(asf);
            }

            var customerAccountSpec = new GetCustomerAccountWithCustomerKeySpec(customer.CustomerId);
            var customerAccounts = await _customerAccountRepository.ListAsync(customerAccountSpec);

            foreach (var ca in customerAccounts)
            {
                customer.DeleteCustomerAccount(ca.AccountId, customer.CustomerId);
            }

            var customerAddressSpec = new GetCustomerAddressWithCustomerKeySpec(customer.CustomerId);
            var customerAddresses = await _customerAddressRepository.ListAsync(customerAddressSpec);

            foreach (var ca in customerAddresses)
            {
                customer.DeleteCustomerAddress(ca.AddressId, customer.CustomerId);
            }

            var customerAiHistorySpec = new GetCustomerAiHistoryWithCustomerKeySpec(customer.CustomerId);
            var customerAiHistories = await _customerAiHistoryRepository.ListAsync(customerAiHistorySpec);

            foreach (var cah in customerAiHistories)
            {
                customer.DeleteCustomerAiHistory(cah);
            }

            var customerDocumentSpec = new GetCustomerDocumentWithCustomerKeySpec(customer.CustomerId);
            var customerDocuments = await _customerDocumentRepository.ListAsync(customerDocumentSpec);

            foreach (var cd in customerDocuments)
            {
                customer.DeleteCustomerDocument(customer.CustomerId, cd.DocumentId);
            }

            var customerEmailAddressSpec = new GetCustomerEmailAddressWithCustomerKeySpec(customer.CustomerId);
            var customerEmailAddresses = await _customerEmailAddressRepository.ListAsync(customerEmailAddressSpec);

            foreach (var cea in customerEmailAddresses)
            {
                customer.DeleteCustomerEmailAddress(customer.CustomerId, cea.EmailAddressId);
            }

            var customerFeedbackSpec = new GetCustomerFeedbackWithCustomerKeySpec(customer.CustomerId);
            var customerFeedbacks = await _customerFeedbackRepository.ListAsync(customerFeedbackSpec);

            foreach (var cf in customerFeedbacks)
            {
                customer.DeleteCustomerFeedback(cf);
            }

            var customerPhoneNumberSpec = new GetCustomerPhoneNumberWithCustomerKeySpec(customer.CustomerId);
            var customerPhoneNumbers = await _customerPhoneNumberRepository.ListAsync(customerPhoneNumberSpec);

            foreach (var cpn in customerPhoneNumbers)
            {
                customer.DeleteCustomerPhoneNumber(customer.CustomerId, cpn.PhoneNumberId);
            }

            var customerPurchaseSpec = new GetCustomerPurchaseWithCustomerKeySpec(customer.CustomerId);
            var customerPurchases = await _customerPurchaseRepository.ListAsync(customerPurchaseSpec);

            foreach (var cp in customerPurchases)
            {
                customer.DeleteCustomerPurchase(cp);
            }

            var customerReviewSpec = new GetCustomerReviewWithCustomerKeySpec(customer.CustomerId);
            var customerReviews = await _customerReviewRepository.ListAsync(customerReviewSpec);

            foreach (var cr in customerReviews)
            {
                customer.DeleteCustomerReview(cr);
            }

            var discountCodeRedemptionSpec = new GetDiscountCodeRedemptionWithCustomerKeySpec(customer.CustomerId);
            var discountCodeRedemptions = await _discountCodeRedemptionRepository.ListAsync(discountCodeRedemptionSpec);

            foreach (var dcr in discountCodeRedemptions)
            {
                customer.DeleteDiscountCodeRedemption(dcr.DiscountCodeRedemptionDate, customer.CustomerId,
                    dcr.DiscountCodeId);
            }

            var giftCodeRedemptionSpec = new GetGiftCodeRedemptionWithCustomerKeySpec(customer.CustomerId);
            var giftCodeRedemptions = await _giftCodeRedemptionRepository.ListAsync(giftCodeRedemptionSpec);

            foreach (var gcr in giftCodeRedemptions)
            {
                customer.DeleteGiftCodeRedemption(gcr);
            }

            var messageSpec = new GetMessageWithCustomerKeySpec(customer.CustomerId);
            var messages = await _messageRepository.ListAsync(messageSpec);

            foreach (var m in messages)
            {
                customer.DeleteMessage(m);
            }

            var prepaidPackageRedemptionSpec = new GetPrepaidPackageRedemptionWithCustomerKeySpec(customer.CustomerId);
            var prepaidPackageRedemptions =
                await _prepaidPackageRedemptionRepository.ListAsync(prepaidPackageRedemptionSpec);

            foreach (var ppr in prepaidPackageRedemptions)
            {
                customer.DeletePrepaidPackageRedemption(ppr);
            }

            var serfinsaPaymentSpec = new GetSerfinsaPaymentWithCustomerKeySpec(customer.CustomerId);
            var serfinsaPayments = await _serfinsaPaymentRepository.ListAsync(serfinsaPaymentSpec);

            foreach (var sp in serfinsaPayments)
            {
                customer.DeleteSerfinsaPayment(sp);
                // await _repository.UpdateAsync(customer);
            }

            var unansweredConversationSpec = new GetUnansweredConversationWithCustomerKeySpec(customer.CustomerId);
            var unansweredConversations = await _unansweredConversationRepository.ListAsync(unansweredConversationSpec);

            foreach (var uc in unansweredConversations)
            {
                customer.DeleteUnansweredConversation(uc);
            }

            await _repository.UpdateAsync(customer);


            var customerDeletedEvent = new CustomerDeletedEvent(customer, "Mongo-History");
            // _messagePublisher.Publish(customerDeletedEvent);

            try
            {
                await _repository.DeleteAsync(customer);
            }
            catch (Exception e)
            {
                var ss = 6;
            }


            return Ok(response);
        }
    }
}