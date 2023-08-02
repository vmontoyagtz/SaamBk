using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SaamApp.BlazorMauiShared.Models.CustomerPurchase;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.CustomerPurchaseEndpoints
{
    public class Create : EndpointBaseAsync.WithRequest<CreateCustomerPurchaseRequest>.WithActionResult<
        CreateCustomerPurchaseResponse>
    {
        private readonly IRepository<Customer> _customerRepository;

        private readonly ILogger<Create> _logger;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<CustomerPurchase> _repository;

        public Create(
            IRepository<CustomerPurchase> repository,
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

        [HttpPost("api/customerPurchases")]
        [SwaggerOperation(
            Summary = "Creates a new CustomerPurchase",
            Description = "Creates a new CustomerPurchase",
            OperationId = "customerPurchases.create",
            Tags = new[] { "CustomerPurchaseEndpoints" })
        ]
        public override async Task<ActionResult<CreateCustomerPurchaseResponse>> HandleAsync(
            CreateCustomerPurchaseRequest request,
            CancellationToken cancellationToken)

        {
            var response = new CreateCustomerPurchaseResponse(request.CorrelationId());

            //var customer = await _customerRepository.GetByIdAsync(request.CustomerId);// parent entity

            var newCustomerPurchase = new CustomerPurchase(
                Guid.NewGuid(),
                request.CustomerId,
                request.ReferenceId,
                request.ReferenceIdDescription,
                request.TransactionAmount,
                request.CustomerPurchaseTotal,
                request.IsPositive,
                request.IsNegative,
                request.CreatedAt,
                request.CreatedBy,
                request.UpdatedAt,
                request.UpdatedBy,
                request.IsDeleted
            );


            await _repository.AddAsync(newCustomerPurchase);

            _logger.LogInformation(
                $"CustomerPurchase created  with Id {newCustomerPurchase.CustomerPurchaseId.ToString("D", CultureInfo.InvariantCulture)}");

            var dto = _mapper.Map<CustomerPurchaseDto>(newCustomerPurchase);

            var customerPurchaseCreatedEvent = new CustomerPurchaseCreatedEvent(newCustomerPurchase, "Mongo-History");
            _messagePublisher.Publish(customerPurchaseCreatedEvent);

            response.CustomerPurchase = dto;


            return Ok(response);
        }
    }
}