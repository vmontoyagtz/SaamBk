using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SaamApp.BlazorMauiShared.Models.SerfinsaPayment;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.SerfinsaPaymentEndpoints
{
    public class Create : EndpointBaseAsync.WithRequest<CreateSerfinsaPaymentRequest>.WithActionResult<
        CreateSerfinsaPaymentResponse>
    {
        private readonly IRepository<Customer> _customerRepository;

        private readonly ILogger<Create> _logger;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<SerfinsaPayment> _repository;

        public Create(
            IRepository<SerfinsaPayment> repository,
            IRepository<Customer> customerRepository,
            IMapper mapper,
            IApplicationMessagePublisher messagePublisher,
            ILogger<Create> logger
        )
        {
            _mapper = mapper;
            _messagePublisher = messagePublisher;
            _logger = logger;
            _repository = repository;
            _customerRepository = customerRepository;
        }

        [HttpPost("api/serfinsaPayments")]
        [SwaggerOperation(
            Summary = "Creates a new SerfinsaPayment",
            Description = "Creates a new SerfinsaPayment",
            OperationId = "serfinsaPayments.create",
            Tags = new[] { "SerfinsaPaymentEndpoints" })
        ]
        public override async Task<ActionResult<CreateSerfinsaPaymentResponse>> HandleAsync(
            CreateSerfinsaPaymentRequest request,
            CancellationToken cancellationToken)

        {
            var response = new CreateSerfinsaPaymentResponse(request.CorrelationId());

            //var customer = await _customerRepository.GetByIdAsync(request.CustomerId);// parent entity

            var newSerfinsaPayment = new SerfinsaPayment(
                Guid.NewGuid(),
                request.CustomerId,
                request.DiscountCodeId,
                request.PrepaidPackageId,
                request.SerfinsaPaymentAmount,
                request.SerfinsaPaymentTime,
                request.SerfinsaPaymentDate,
                request.SerfinsaPaymentReferenceNumber,
                request.SerfinsaPaymentAuditNo,
                request.SerfinsaPaymentTimeMessageType,
                request.SerfinsaPaymentTimeAuthorize,
                request.SerfinsaPaymentTimeAnswer,
                request.SerfinsaPaymentTimeType,
                request.CreatedAt,
                request.CreatedBy,
                request.UpdatedAt,
                request.UpdatedBy,
                request.IsDeleted,
                request.TenantId
            );


            await _repository.AddAsync(newSerfinsaPayment);

            _logger.LogInformation(
                $"SerfinsaPayment created  with Id {newSerfinsaPayment.SerfinsaPaymentId.ToString("D", CultureInfo.InvariantCulture)}");

            var dto = _mapper.Map<SerfinsaPaymentDto>(newSerfinsaPayment);

            var serfinsaPaymentCreatedEvent = new SerfinsaPaymentCreatedEvent(newSerfinsaPayment, "Mongo-History");
            _messagePublisher.Publish(serfinsaPaymentCreatedEvent);

            response.SerfinsaPayment = dto;


            return Ok(response);
        }
    }
}