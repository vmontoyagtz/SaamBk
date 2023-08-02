using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SaamApp.BlazorMauiShared.Models.CustomerFeedback;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.CustomerFeedbackEndpoints
{
    public class Create : EndpointBaseAsync.WithRequest<CreateCustomerFeedbackRequest>.WithActionResult<
        CreateCustomerFeedbackResponse>
    {
        private readonly IRepository<Customer> _customerRepository;

        private readonly ILogger<Create> _logger;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<CustomerFeedback> _repository;

        public Create(
            IRepository<CustomerFeedback> repository,
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

        [HttpPost("api/customerFeedbacks")]
        [SwaggerOperation(
            Summary = "Creates a new CustomerFeedback",
            Description = "Creates a new CustomerFeedback",
            OperationId = "customerFeedbacks.create",
            Tags = new[] { "CustomerFeedbackEndpoints" })
        ]
        public override async Task<ActionResult<CreateCustomerFeedbackResponse>> HandleAsync(
            CreateCustomerFeedbackRequest request,
            CancellationToken cancellationToken)

        {
            var response = new CreateCustomerFeedbackResponse(request.CorrelationId());

            //var customer = await _customerRepository.GetByIdAsync(request.CustomerId);// parent entity

            var newCustomerFeedback = new CustomerFeedback(
                Guid.NewGuid(),
                request.CustomerId,
                request.FeedbackDate,
                request.FeedbackContent
            );


            await _repository.AddAsync(newCustomerFeedback);

            _logger.LogInformation(
                $"CustomerFeedback created  with Id {newCustomerFeedback.FeedbackId.ToString("D", CultureInfo.InvariantCulture)}");

            var dto = _mapper.Map<CustomerFeedbackDto>(newCustomerFeedback);

            var customerFeedbackCreatedEvent = new CustomerFeedbackCreatedEvent(newCustomerFeedback, "Mongo-History");
            _messagePublisher.Publish(customerFeedbackCreatedEvent);

            response.CustomerFeedback = dto;


            return Ok(response);
        }
    }
}