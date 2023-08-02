using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SaamApp.BlazorMauiShared.Models.CustomerPayment;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.CustomerPaymentEndpoints
{
    public class Create : EndpointBaseAsync.WithRequest<CreateCustomerPaymentRequest>.WithActionResult<
        CreateCustomerPaymentResponse>
    {
        private readonly ILogger<Create> _logger;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<PaymentMethod> _paymentMethodRepository;
        private readonly IRepository<CustomerPayment> _repository;

        public Create(
            IRepository<CustomerPayment> repository,
            IRepository<PaymentMethod> paymentMethodRepository,
            IMapper mapper,
            IApplicationMessagePublisher messagePublisher,
            ILogger<Create> logger
        )
        {
            _mapper = mapper;
            _messagePublisher = messagePublisher;
            _logger = logger;
            _repository = repository;
            _paymentMethodRepository = paymentMethodRepository;
        }

        [HttpPost("api/customerPayments")]
        [SwaggerOperation(
            Summary = "Creates a new CustomerPayment",
            Description = "Creates a new CustomerPayment",
            OperationId = "customerPayments.create",
            Tags = new[] { "CustomerPaymentEndpoints" })
        ]
        public override async Task<ActionResult<CreateCustomerPaymentResponse>> HandleAsync(
            CreateCustomerPaymentRequest request,
            CancellationToken cancellationToken)

        {
            var response = new CreateCustomerPaymentResponse(request.CorrelationId());

            //var paymentMethod = await _paymentMethodRepository.GetByIdAsync(request.PaymentMethodId);// parent entity

            var newCustomerPayment = new CustomerPayment(
                request.PaymentMethodId,
                request.SerfinsaPaymentId,
                request.TenantId
            );


            await _repository.AddAsync(newCustomerPayment);

            _logger.LogInformation(
                $"CustomerPayment created  with Id {newCustomerPayment.RowId.ToString("D", CultureInfo.InvariantCulture)}");

            var dto = _mapper.Map<CustomerPaymentDto>(newCustomerPayment);

            var customerPaymentCreatedEvent = new CustomerPaymentCreatedEvent(newCustomerPayment, "Mongo-History");
            _messagePublisher.Publish(customerPaymentCreatedEvent);

            response.CustomerPayment = dto;


            return Ok(response);
        }
    }
}