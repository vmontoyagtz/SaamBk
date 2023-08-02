using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SaamApp.BlazorMauiShared.Models.BusinessUnitAddress;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.BusinessUnitAddressEndpoints
{
    public class Create : EndpointBaseAsync.WithRequest<CreateBusinessUnitAddressRequest>.WithActionResult<
        CreateBusinessUnitAddressResponse>
    {
        private readonly IRepository<Address> _addressRepository;

        private readonly ILogger<Create> _logger;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<BusinessUnitAddress> _repository;

        public Create(
            IRepository<BusinessUnitAddress> repository,
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

        [HttpPost("api/businessUnitAddresses")]
        [SwaggerOperation(
            Summary = "Creates a new BusinessUnitAddress",
            Description = "Creates a new BusinessUnitAddress",
            OperationId = "businessUnitAddresses.create",
            Tags = new[] { "BusinessUnitAddressEndpoints" })
        ]
        public override async Task<ActionResult<CreateBusinessUnitAddressResponse>> HandleAsync(
            CreateBusinessUnitAddressRequest request,
            CancellationToken cancellationToken)

        {
            var response = new CreateBusinessUnitAddressResponse(request.CorrelationId());

            //var address = await _addressRepository.GetByIdAsync(request.AddressId);// parent entity

            var newBusinessUnitAddress = new BusinessUnitAddress(
                request.AddressId,
                request.AddressTypeId,
                request.BusinessUnitId
            );


            await _repository.AddAsync(newBusinessUnitAddress);

            _logger.LogInformation(
                $"BusinessUnitAddress created  with Id {newBusinessUnitAddress.RowId.ToString("D", CultureInfo.InvariantCulture)}");

            var dto = _mapper.Map<BusinessUnitAddressDto>(newBusinessUnitAddress);

            var businessUnitAddressCreatedEvent =
                new BusinessUnitAddressCreatedEvent(newBusinessUnitAddress, "Mongo-History");
            _messagePublisher.Publish(businessUnitAddressCreatedEvent);

            response.BusinessUnitAddress = dto;


            return Ok(response);
        }
    }
}