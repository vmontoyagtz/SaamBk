using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SaamApp.BlazorMauiShared.Models.Customer;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.CustomerEndpoints
{
    public class Create : EndpointBaseAsync.WithRequest<CreateCustomerRequest>.WithActionResult<
        CreateCustomerResponse>
    {
        private readonly IRepository<Gender> _genderRepository;

        private readonly ILogger<Create> _logger;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<Customer> _repository;

        public Create(
            IRepository<Customer> repository,
            IRepository<Gender> genderRepository,
            IMapper mapper,
            IApplicationMessagePublisher messagePublisher,
            ILogger<Create> logger
        )
        {
            _mapper = mapper;
            _messagePublisher = messagePublisher;
            _logger = logger;
            _repository = repository;
            _genderRepository = genderRepository;
        }

        [HttpPost("api/customers")]
        [SwaggerOperation(
            Summary = "Creates a new Customer",
            Description = "Creates a new Customer",
            OperationId = "customers.create",
            Tags = new[] { "CustomerEndpoints" })
        ]
        public override async Task<ActionResult<CreateCustomerResponse>> HandleAsync(
            CreateCustomerRequest request,
            CancellationToken cancellationToken)

        {
            var response = new CreateCustomerResponse(request.CorrelationId());

            //var gender = await _genderRepository.GetByIdAsync(request.GenderId);// parent entity

            var newCustomer = new Customer(
                Guid.NewGuid(),
                request.GenderId,
                request.CustomerFirstName,
                request.CustomerLastName,
                request.CustomerProfileThumbnailPath,
                request.CustomerBirthDate,
                request.CreatedAt,
                request.CreatedBy,
                request.UpdatedAt,
                request.UpdatedBy,
                request.IsDeleted,
                request.TenantId
            );


            await _repository.AddAsync(newCustomer);

            _logger.LogInformation(
                $"Customer created  with Id {newCustomer.CustomerId.ToString("D", CultureInfo.InvariantCulture)}");

            var dto = _mapper.Map<CustomerDto>(newCustomer);

            var customerCreatedEvent = new CustomerCreatedEvent(newCustomer, "Mongo-History");
            _messagePublisher.Publish(customerCreatedEvent);

            response.Customer = dto;


            return Ok(response);
        }
    }
}