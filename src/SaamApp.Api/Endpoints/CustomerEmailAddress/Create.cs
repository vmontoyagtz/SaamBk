using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SaamApp.BlazorMauiShared.Models.CustomerEmailAddress;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.CustomerEmailAddressEndpoints
{
    public class Create : EndpointBaseAsync.WithRequest<CreateCustomerEmailAddressRequest>.WithActionResult<
        CreateCustomerEmailAddressResponse>
    {
        private readonly IRepository<Customer> _customerRepository;

        private readonly ILogger<Create> _logger;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<CustomerEmailAddress> _repository;

        public Create(
            IRepository<CustomerEmailAddress> repository,
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

        [HttpPost("api/customerEmailAddresses")]
        [SwaggerOperation(
            Summary = "Creates a new CustomerEmailAddress",
            Description = "Creates a new CustomerEmailAddress",
            OperationId = "customerEmailAddresses.create",
            Tags = new[] { "CustomerEmailAddressEndpoints" })
        ]
        public override async Task<ActionResult<CreateCustomerEmailAddressResponse>> HandleAsync(
            CreateCustomerEmailAddressRequest request,
            CancellationToken cancellationToken)

        {
            var response = new CreateCustomerEmailAddressResponse(request.CorrelationId());

            //var customer = await _customerRepository.GetByIdAsync(request.CustomerId);// parent entity

            var newCustomerEmailAddress = new CustomerEmailAddress(
                request.CustomerId,
                request.EmailAddressId,
                request.EmailAddressTypeId
            );


            await _repository.AddAsync(newCustomerEmailAddress);

            _logger.LogInformation(
                $"CustomerEmailAddress created  with Id {newCustomerEmailAddress.RowId.ToString("D", CultureInfo.InvariantCulture)}");

            var dto = _mapper.Map<CustomerEmailAddressDto>(newCustomerEmailAddress);

            var customerEmailAddressCreatedEvent =
                new CustomerEmailAddressCreatedEvent(newCustomerEmailAddress, "Mongo-History");
            _messagePublisher.Publish(customerEmailAddressCreatedEvent);

            response.CustomerEmailAddress = dto;


            return Ok(response);
        }
    }
}