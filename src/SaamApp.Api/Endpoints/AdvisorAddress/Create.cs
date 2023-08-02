using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SaamApp.BlazorMauiShared.Models.AdvisorAddress;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.AdvisorAddressEndpoints
{
    public class Create : EndpointBaseAsync.WithRequest<CreateAdvisorAddressRequest>.WithActionResult<
        CreateAdvisorAddressResponse>
    {
        private readonly IRepository<Address> _addressRepository;

        private readonly ILogger<Create> _logger;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<AdvisorAddress> _repository;

        public Create(
            IRepository<AdvisorAddress> repository,
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

        [HttpPost("api/advisorAddresses")]
        [SwaggerOperation(
            Summary = "Creates a new AdvisorAddress",
            Description = "Creates a new AdvisorAddress",
            OperationId = "advisorAddresses.create",
            Tags = new[] { "AdvisorAddressEndpoints" })
        ]
        public override async Task<ActionResult<CreateAdvisorAddressResponse>> HandleAsync(
            CreateAdvisorAddressRequest request,
            CancellationToken cancellationToken)

        {
            var response = new CreateAdvisorAddressResponse(request.CorrelationId());

            //var address = await _addressRepository.GetByIdAsync(request.AddressId);// parent entity

            var newAdvisorAddress = new AdvisorAddress(
                request.AddressId,
                request.AddressTypeId,
                request.AdvisorId
            );


            await _repository.AddAsync(newAdvisorAddress);

            _logger.LogInformation(
                $"AdvisorAddress created  with Id {newAdvisorAddress.RowId.ToString("D", CultureInfo.InvariantCulture)}");

            var dto = _mapper.Map<AdvisorAddressDto>(newAdvisorAddress);

            var advisorAddressCreatedEvent = new AdvisorAddressCreatedEvent(newAdvisorAddress, "Mongo-History");
            _messagePublisher.Publish(advisorAddressCreatedEvent);

            response.AdvisorAddress = dto;


            return Ok(response);
        }
    }
}