using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SaamApp.BlazorMauiShared.Models.AdvisorPayment;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.AdvisorPaymentEndpoints
{
    public class Create : EndpointBaseAsync.WithRequest<CreateAdvisorPaymentRequest>.WithActionResult<
        CreateAdvisorPaymentResponse>
    {
        private readonly IRepository<Advisor> _advisorRepository;

        private readonly ILogger<Create> _logger;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<AdvisorPayment> _repository;

        public Create(
            IRepository<AdvisorPayment> repository,
            IRepository<Advisor> advisorRepository,
            IMapper mapper,
            IApplicationMessagePublisher messagePublisher,
            ILogger<Create> logger
        )
        {
            _mapper = mapper;
            _messagePublisher = messagePublisher;
            _logger = logger;
            _repository = repository;
            _advisorRepository = advisorRepository;
        }

        [HttpPost("api/advisorPayments")]
        [SwaggerOperation(
            Summary = "Creates a new AdvisorPayment",
            Description = "Creates a new AdvisorPayment",
            OperationId = "advisorPayments.create",
            Tags = new[] { "AdvisorPaymentEndpoints" })
        ]
        public override async Task<ActionResult<CreateAdvisorPaymentResponse>> HandleAsync(
            CreateAdvisorPaymentRequest request,
            CancellationToken cancellationToken)

        {
            var response = new CreateAdvisorPaymentResponse(request.CorrelationId());

            //var advisor = await _advisorRepository.GetByIdAsync(request.AdvisorId);// parent entity

            var newAdvisorPayment = new AdvisorPayment(
                request.AdvisorId,
                request.BankAccountId,
                request.PaymentMethodId,
                request.AdvisorPaymentDescription,
                request.AdvisorPaymentsAmount,
                request.CreatedAt,
                request.CreatedBy,
                request.UpdatedAt,
                request.UpdatedBy,
                request.IsDeleted
            );


            await _repository.AddAsync(newAdvisorPayment);

            _logger.LogInformation(
                $"AdvisorPayment created  with Id {newAdvisorPayment.RowId.ToString("D", CultureInfo.InvariantCulture)}");

            var dto = _mapper.Map<AdvisorPaymentDto>(newAdvisorPayment);

            var advisorPaymentCreatedEvent = new AdvisorPaymentCreatedEvent(newAdvisorPayment, "Mongo-History");
            _messagePublisher.Publish(advisorPaymentCreatedEvent);

            response.AdvisorPayment = dto;


            return Ok(response);
        }
    }
}