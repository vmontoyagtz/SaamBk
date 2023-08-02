using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SaamApp.BlazorMauiShared.Models.CustomerAddress;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.CustomerAddressEndpoints
{
    public class Create : EndpointBaseAsync.WithRequest<CreateCustomerAddressRequest>.WithActionResult<
        CreateCustomerAddressResponse>
    {
        private readonly IRepository<Address> _addressRepository;

        private readonly ILogger<Create> _logger;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<CustomerAddress> _repository;

        public Create(
            IRepository<CustomerAddress> repository,
            IRepository<Address> addressRepository,
            IMapper mapper,
            IApplicationMessagePublisher messagePublisher,
            ILogger<Create> logger
        )
        {
            _mapper = mapper;
            _messagePublisher = messagePublisher;
            _logger = logger;
            _repository = repository;
            _addressRepository = addressRepository;
        }

        [HttpPost("api/customerAddresses")]
        [SwaggerOperation(
            Summary = "Creates a new CustomerAddress",
            Description = "Creates a new CustomerAddress",
            OperationId = "customerAddresses.create",
            Tags = new[] { "CustomerAddressEndpoints" })
        ]
        public override async Task<ActionResult<CreateCustomerAddressResponse>> HandleAsync(
            CreateCustomerAddressRequest request,
            CancellationToken cancellationToken)

        {
            var response = new CreateCustomerAddressResponse(request.CorrelationId());

            //var address = await _addressRepository.GetByIdAsync(request.AddressId);// parent entity

            var newCustomerAddress = new CustomerAddress(
                request.AddressId,
                request.AddressTypeId,
                request.CustomerId
            );


            await _repository.AddAsync(newCustomerAddress);

            _logger.LogInformation(
                $"CustomerAddress created  with Id {newCustomerAddress.RowId.ToString("D", CultureInfo.InvariantCulture)}");

            var dto = _mapper.Map<CustomerAddressDto>(newCustomerAddress);

            var customerAddressCreatedEvent = new CustomerAddressCreatedEvent(newCustomerAddress, "Mongo-History");
            _messagePublisher.Publish(customerAddressCreatedEvent);

            response.CustomerAddress = dto;


            return Ok(response);
        }
    }
}