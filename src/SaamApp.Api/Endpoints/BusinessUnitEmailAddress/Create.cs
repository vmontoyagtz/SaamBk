using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SaamApp.BlazorMauiShared.Models.BusinessUnitEmailAddress;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.BusinessUnitEmailAddressEndpoints
{
    public class Create : EndpointBaseAsync.WithRequest<CreateBusinessUnitEmailAddressRequest>.WithActionResult<
        CreateBusinessUnitEmailAddressResponse>
    {
        private readonly IRepository<BusinessUnit> _businessUnitRepository;

        private readonly ILogger<Create> _logger;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<BusinessUnitEmailAddress> _repository;

        public Create(
            IRepository<BusinessUnitEmailAddress> repository,
            IRepository<BusinessUnit> businessUnitRepository,
            IMapper mapper,
            IApplicationMessagePublisher messagePublisher,
            ILogger<Create> logger
        )
        {
            _mapper = mapper;
            _messagePublisher = messagePublisher;
            _logger = logger;
            _repository = repository;
            _businessUnitRepository = businessUnitRepository;
        }

        [HttpPost("api/businessUnitEmailAddresses")]
        [SwaggerOperation(
            Summary = "Creates a new BusinessUnitEmailAddress",
            Description = "Creates a new BusinessUnitEmailAddress",
            OperationId = "businessUnitEmailAddresses.create",
            Tags = new[] { "BusinessUnitEmailAddressEndpoints" })
        ]
        public override async Task<ActionResult<CreateBusinessUnitEmailAddressResponse>> HandleAsync(
            CreateBusinessUnitEmailAddressRequest request,
            CancellationToken cancellationToken)

        {
            var response = new CreateBusinessUnitEmailAddressResponse(request.CorrelationId());

            //var businessUnit = await _businessUnitRepository.GetByIdAsync(request.BusinessUnitId);// parent entity

            var newBusinessUnitEmailAddress = new BusinessUnitEmailAddress(
                request.BusinessUnitId,
                request.EmailAddressId,
                request.EmailAddressTypeId
            );


            await _repository.AddAsync(newBusinessUnitEmailAddress);

            _logger.LogInformation(
                $"BusinessUnitEmailAddress created  with Id {newBusinessUnitEmailAddress.RowId.ToString("D", CultureInfo.InvariantCulture)}");

            var dto = _mapper.Map<BusinessUnitEmailAddressDto>(newBusinessUnitEmailAddress);

            var businessUnitEmailAddressCreatedEvent =
                new BusinessUnitEmailAddressCreatedEvent(newBusinessUnitEmailAddress, "Mongo-History");
            _messagePublisher.Publish(businessUnitEmailAddressCreatedEvent);

            response.BusinessUnitEmailAddress = dto;


            return Ok(response);
        }
    }
}