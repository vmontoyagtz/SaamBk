using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SaamApp.BlazorMauiShared.Models.CustomerAiHistory;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.CustomerAiHistoryEndpoints
{
    public class Create : EndpointBaseAsync.WithRequest<CreateCustomerAiHistoryRequest>.WithActionResult<
        CreateCustomerAiHistoryResponse>
    {
        private readonly IRepository<Customer> _customerRepository;

        private readonly ILogger<Create> _logger;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<CustomerAiHistory> _repository;

        public Create(
            IRepository<CustomerAiHistory> repository,
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

        [HttpPost("api/customerAiHistories")]
        [SwaggerOperation(
            Summary = "Creates a new CustomerAiHistory",
            Description = "Creates a new CustomerAiHistory",
            OperationId = "customerAiHistories.create",
            Tags = new[] { "CustomerAiHistoryEndpoints" })
        ]
        public override async Task<ActionResult<CreateCustomerAiHistoryResponse>> HandleAsync(
            CreateCustomerAiHistoryRequest request,
            CancellationToken cancellationToken)

        {
            var response = new CreateCustomerAiHistoryResponse(request.CorrelationId());

            //var customer = await _customerRepository.GetByIdAsync(request.CustomerId);// parent entity

            var newCustomerAiHistory = new CustomerAiHistory(
                Guid.NewGuid(),
                request.CustomerId,
                request.ModelId,
                request.Question,
                request.Response,
                request.InteractionTime,
                request.TenantId
            );


            await _repository.AddAsync(newCustomerAiHistory);

            _logger.LogInformation(
                $"CustomerAiHistory created  with Id {newCustomerAiHistory.CustomerAiHistoryId.ToString("D", CultureInfo.InvariantCulture)}");

            var dto = _mapper.Map<CustomerAiHistoryDto>(newCustomerAiHistory);

            var customerAiHistoryCreatedEvent =
                new CustomerAiHistoryCreatedEvent(newCustomerAiHistory, "Mongo-History");
            _messagePublisher.Publish(customerAiHistoryCreatedEvent);

            response.CustomerAiHistory = dto;


            return Ok(response);
        }
    }
}