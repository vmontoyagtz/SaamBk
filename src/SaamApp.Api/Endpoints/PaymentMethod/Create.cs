using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SaamApp.BlazorMauiShared.Models.PaymentMethod;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.PaymentMethodEndpoints
{
    public class Create : EndpointBaseAsync.WithRequest<CreatePaymentMethodRequest>.WithActionResult<
        CreatePaymentMethodResponse>
    {
        private readonly ILogger<Create> _logger;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<PaymentMethod> _repository;

        public Create(
            IRepository<PaymentMethod> repository,
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

        [HttpPost("api/paymentMethods")]
        [SwaggerOperation(
            Summary = "Creates a new PaymentMethod",
            Description = "Creates a new PaymentMethod",
            OperationId = "paymentMethods.create",
            Tags = new[] { "PaymentMethodEndpoints" })
        ]
        public override async Task<ActionResult<CreatePaymentMethodResponse>> HandleAsync(
            CreatePaymentMethodRequest request,
            CancellationToken cancellationToken)

        {
            var response = new CreatePaymentMethodResponse(request.CorrelationId());


            var newPaymentMethod = new PaymentMethod(
                Guid.NewGuid(),
                request.PaymentFrequencyCode,
                request.PaymentMethodName,
                request.PaymentMethodDescription,
                request.TenantId
            );


            await _repository.AddAsync(newPaymentMethod);

            _logger.LogInformation(
                $"PaymentMethod created  with Id {newPaymentMethod.PaymentMethodId.ToString("D", CultureInfo.InvariantCulture)}");

            var dto = _mapper.Map<PaymentMethodDto>(newPaymentMethod);

            var paymentMethodCreatedEvent = new PaymentMethodCreatedEvent(newPaymentMethod, "Mongo-History");
            _messagePublisher.Publish(paymentMethodCreatedEvent);

            response.PaymentMethod = dto;


            return Ok(response);
        }
    }
}