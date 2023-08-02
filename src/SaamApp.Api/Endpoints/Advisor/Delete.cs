using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.Advisor;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.AdvisorEndpoints
{
    public class Delete : EndpointBaseAsync.WithRequest<DeleteAdvisorRequest>.WithActionResult<
        DeleteAdvisorResponse>
    {
        private readonly IRepository<AdvisorAddress> _advisorAddressRepository;
        private readonly IRepository<AdvisorBank> _advisorBankRepository;
        private readonly IRepository<AdvisorBankTransferInfo> _advisorBankTransferInfoRepository;
        private readonly IRepository<AdvisorCustomer> _advisorCustomerRepository;
        private readonly IRepository<AdvisorDocument> _advisorDocumentRepository;
        private readonly IRepository<AdvisorEmailAddress> _advisorEmailAddressRepository;
        private readonly IRepository<AdvisorIdentityDocument> _advisorIdentityDocumentRepository;
        private readonly IRepository<AdvisorLogin> _advisorLoginRepository;
        private readonly IRepository<AdvisorPayment> _advisorPaymentRepository;
        private readonly IRepository<AdvisorPhoneNumber> _advisorPhoneNumberRepository;
        private readonly IRepository<AdvisorRating> _advisorRatingRepository;
        private readonly IRepository<Advisor> _advisorReadRepository;
        private readonly IRepository<AppointmentSchedule> _appointmentScheduleRepository;
        private readonly IRepository<CustomerReview> _customerReviewRepository;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<Message> _messageRepository;
        private readonly IRepository<RegionAreaAdvisorCategory> _regionAreaAdvisorCategoryRepository;
        private readonly IRepository<Advisor> _repository;
        private readonly IRepository<TrainingProgress> _trainingProgressRepository;
        private readonly IRepository<TrainingQuizHistory> _trainingQuizHistoryRepository;

        public Delete(IRepository<Advisor> AdvisorRepository, IRepository<Advisor> AdvisorReadRepository,
            IRepository<AdvisorAddress> advisorAddressRepository,
            IRepository<AdvisorBank> advisorBankRepository,
            IRepository<AdvisorBankTransferInfo> advisorBankTransferInfoRepository,
            IRepository<AdvisorCustomer> advisorCustomerRepository,
            IRepository<AdvisorDocument> advisorDocumentRepository,
            IRepository<AdvisorEmailAddress> advisorEmailAddressRepository,
            IRepository<AdvisorIdentityDocument> advisorIdentityDocumentRepository,
            IRepository<AdvisorLogin> advisorLoginRepository,
            IRepository<AdvisorPayment> advisorPaymentRepository,
            IRepository<AdvisorPhoneNumber> advisorPhoneNumberRepository,
            IRepository<AdvisorRating> advisorRatingRepository,
            IRepository<AppointmentSchedule> appointmentScheduleRepository,
            IRepository<CustomerReview> customerReviewRepository,
            IRepository<Message> messageRepository,
            IRepository<RegionAreaAdvisorCategory> regionAreaAdvisorCategoryRepository,
            IRepository<TrainingProgress> trainingProgressRepository,
            IRepository<TrainingQuizHistory> trainingQuizHistoryRepository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = AdvisorRepository;
            _advisorReadRepository = AdvisorReadRepository;
            _advisorAddressRepository = advisorAddressRepository;
            _advisorBankRepository = advisorBankRepository;
            _advisorBankTransferInfoRepository = advisorBankTransferInfoRepository;
            _advisorCustomerRepository = advisorCustomerRepository;
            _advisorDocumentRepository = advisorDocumentRepository;
            _advisorEmailAddressRepository = advisorEmailAddressRepository;
            _advisorIdentityDocumentRepository = advisorIdentityDocumentRepository;
            _advisorLoginRepository = advisorLoginRepository;
            _advisorPaymentRepository = advisorPaymentRepository;
            _advisorPhoneNumberRepository = advisorPhoneNumberRepository;
            _advisorRatingRepository = advisorRatingRepository;
            _appointmentScheduleRepository = appointmentScheduleRepository;
            _customerReviewRepository = customerReviewRepository;
            _messageRepository = messageRepository;
            _regionAreaAdvisorCategoryRepository = regionAreaAdvisorCategoryRepository;
            _trainingProgressRepository = trainingProgressRepository;
            _trainingQuizHistoryRepository = trainingQuizHistoryRepository;
            _mapper = mapper;
        }

        [HttpDelete("api/advisors/{AdvisorId}")]
        [SwaggerOperation(
            Summary = "Deletes an Advisor",
            Description = "Deletes an Advisor",
            OperationId = "advisors.delete",
            Tags = new[] { "AdvisorEndpoints" })
        ]
        public override async Task<ActionResult<DeleteAdvisorResponse>> HandleAsync(
            [FromRoute] DeleteAdvisorRequest request, CancellationToken cancellationToken)
        {
            var response = new DeleteAdvisorResponse(request.CorrelationId());

            var advisor = await _advisorReadRepository.GetByIdAsync(request.AdvisorId);

            if (advisor == null)
            {
                return NotFound();
            }

            var advisorAddressSpec = new GetAdvisorAddressWithAdvisorKeySpec(advisor.AdvisorId);
            var advisorAddresses = await _advisorAddressRepository.ListAsync(advisorAddressSpec);
            await _advisorAddressRepository.DeleteRangeAsync(advisorAddresses);
            var advisorBankSpec = new GetAdvisorBankWithAdvisorKeySpec(advisor.AdvisorId);
            var advisorBanks = await _advisorBankRepository.ListAsync(advisorBankSpec);
            await _advisorBankRepository.DeleteRangeAsync(advisorBanks);
            var advisorBankTransferInfoSpec = new GetAdvisorBankTransferInfoWithAdvisorKeySpec(advisor.AdvisorId);
            var advisorBankTransferInfoes =
                await _advisorBankTransferInfoRepository.ListAsync(advisorBankTransferInfoSpec);
            await _advisorBankTransferInfoRepository
                .DeleteRangeAsync(advisorBankTransferInfoes); // you could use soft delete with IsDeleted = true
            var advisorCustomerSpec = new GetAdvisorCustomerWithAdvisorKeySpec(advisor.AdvisorId);
            var advisorCustomers = await _advisorCustomerRepository.ListAsync(advisorCustomerSpec);
            await _advisorCustomerRepository.DeleteRangeAsync(advisorCustomers);
            var advisorDocumentSpec = new GetAdvisorDocumentWithAdvisorKeySpec(advisor.AdvisorId);
            var advisorDocuments = await _advisorDocumentRepository.ListAsync(advisorDocumentSpec);
            await _advisorDocumentRepository.DeleteRangeAsync(advisorDocuments);
            var advisorEmailAddressSpec = new GetAdvisorEmailAddressWithAdvisorKeySpec(advisor.AdvisorId);
            var advisorEmailAddresses = await _advisorEmailAddressRepository.ListAsync(advisorEmailAddressSpec);
            await _advisorEmailAddressRepository.DeleteRangeAsync(advisorEmailAddresses);
            var advisorIdentityDocumentSpec = new GetAdvisorIdentityDocumentWithAdvisorKeySpec(advisor.AdvisorId);
            var advisorIdentityDocuments =
                await _advisorIdentityDocumentRepository.ListAsync(advisorIdentityDocumentSpec);
            await _advisorIdentityDocumentRepository.DeleteRangeAsync(advisorIdentityDocuments);
            var advisorLoginSpec = new GetAdvisorLoginWithAdvisorKeySpec(advisor.AdvisorId);
            var advisorLogins = await _advisorLoginRepository.ListAsync(advisorLoginSpec);
            await _advisorLoginRepository
                .DeleteRangeAsync(advisorLogins); // you could use soft delete with IsDeleted = true
            var advisorPaymentSpec = new GetAdvisorPaymentWithAdvisorKeySpec(advisor.AdvisorId);
            var advisorPayments = await _advisorPaymentRepository.ListAsync(advisorPaymentSpec);
            await _advisorPaymentRepository.DeleteRangeAsync(advisorPayments);
            var advisorPhoneNumberSpec = new GetAdvisorPhoneNumberWithAdvisorKeySpec(advisor.AdvisorId);
            var advisorPhoneNumbers = await _advisorPhoneNumberRepository.ListAsync(advisorPhoneNumberSpec);
            await _advisorPhoneNumberRepository.DeleteRangeAsync(advisorPhoneNumbers);
            var advisorRatingSpec = new GetAdvisorRatingWithAdvisorKeySpec(advisor.AdvisorId);
            var advisorRatings = await _advisorRatingRepository.ListAsync(advisorRatingSpec);
            await _advisorRatingRepository.DeleteRangeAsync(advisorRatings);
            var appointmentScheduleSpec = new GetAppointmentScheduleWithAdvisorKeySpec(advisor.AdvisorId);
            var appointmentSchedules = await _appointmentScheduleRepository.ListAsync(appointmentScheduleSpec);
            await _appointmentScheduleRepository
                .DeleteRangeAsync(appointmentSchedules); // you could use soft delete with IsDeleted = true
            var customerReviewSpec = new GetCustomerReviewWithAdvisorKeySpec(advisor.AdvisorId);
            var customerReviews = await _customerReviewRepository.ListAsync(customerReviewSpec);
            await _customerReviewRepository
                .DeleteRangeAsync(customerReviews); // you could use soft delete with IsDeleted = true
            var messageSpec = new GetMessageWithAdvisorKeySpec(advisor.AdvisorId);
            var messages = await _messageRepository.ListAsync(messageSpec);
            await _messageRepository.DeleteRangeAsync(messages); // you could use soft delete with IsDeleted = true
            var regionAreaAdvisorCategorySpec = new GetRegionAreaAdvisorCategoryWithAdvisorKeySpec(advisor.AdvisorId);
            var regionAreaAdvisorCategories =
                await _regionAreaAdvisorCategoryRepository.ListAsync(regionAreaAdvisorCategorySpec);
            await _regionAreaAdvisorCategoryRepository
                .DeleteRangeAsync(regionAreaAdvisorCategories); // you could use soft delete with IsDeleted = true
            var trainingProgressSpec = new GetTrainingProgressWithAdvisorKeySpec(advisor.AdvisorId);
            var trainingProgresses = await _trainingProgressRepository.ListAsync(trainingProgressSpec);
            await _trainingProgressRepository
                .DeleteRangeAsync(trainingProgresses); // you could use soft delete with IsDeleted = true
            var trainingQuizHistorySpec = new GetTrainingQuizHistoryWithAdvisorKeySpec(advisor.AdvisorId);
            var trainingQuizHistories = await _trainingQuizHistoryRepository.ListAsync(trainingQuizHistorySpec);
            await _trainingQuizHistoryRepository
                .DeleteRangeAsync(trainingQuizHistories); // you could use soft delete with IsDeleted = true

            var advisorDeletedEvent = new AdvisorDeletedEvent(advisor, "Mongo-History");
            _messagePublisher.Publish(advisorDeletedEvent);

            await _repository.DeleteAsync(advisor);

            return Ok(response);
        }
    }
}