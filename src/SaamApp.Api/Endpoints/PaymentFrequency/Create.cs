using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SaamApp.BlazorMauiShared.Models.PaymentFrequency;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.PaymentFrequencyEndpoints
{
    public class Create : EndpointBaseAsync.WithRequest<CreatePaymentFrequencyRequest>.WithActionResult<
        CreatePaymentFrequencyResponse>
    {
        private readonly ILogger<Create> _logger;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<PaymentFrequency> _repository;

        public Create(
            IRepository<PaymentFrequency> repository,
            IMapper mapper,
            IApplicationMessagePublisher messagePublisher,
            ILogger<Create> logger
        )
        {
            _mapper = mapper;
            _messagePublisher = messagePublisher;
            _logger = logger;
            _repository = repository;
        }

        [HttpPost("api/paymentFrequencies")]
        [SwaggerOperation(
            Summary = "Creates a new PaymentFrequency",
            Description = "Creates a new PaymentFrequency",
            OperationId = "paymentFrequencies.create",
            Tags = new[] { "PaymentFrequencyEndpoints" })
        ]
        public override async Task<ActionResult<CreatePaymentFrequencyResponse>> HandleAsync(
            CreatePaymentFrequencyRequest request,
            CancellationToken cancellationToken)

        {
            var response = new CreatePaymentFrequencyResponse(request.CorrelationId());


            var newPaymentFrequency = new PaymentFrequency(
                Guid.NewGuid(),
                request.PaymentFrequencyName,
                request.PaymentFrequencyValue,
                request.TenantId
            );


            await _repository.AddAsync(newPaymentFrequency);

            _logger.LogInformation(
                $"PaymentFrequency created  with Id {newPaymentFrequency.PaymentFrequencyId.ToString("D", CultureInfo.InvariantCulture)}");

            var dto = _mapper.Map<PaymentFrequencyDto>(newPaymentFrequency);

            var paymentFrequencyCreatedEvent = new PaymentFrequencyCreatedEvent(newPaymentFrequency, "Mongo-History");
            _messagePublisher.Publish(paymentFrequencyCreatedEvent);

            response.PaymentFrequency = dto;


            return Ok(response);
        }
    }
}