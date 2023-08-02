using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SaamApp.BlazorMauiShared.Models.BusinessUnitPhoneNumber;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.BusinessUnitPhoneNumberEndpoints
{
    public class Create : EndpointBaseAsync.WithRequest<CreateBusinessUnitPhoneNumberRequest>.WithActionResult<
        CreateBusinessUnitPhoneNumberResponse>
    {
        private readonly IRepository<BusinessUnit> _businessUnitRepository;

        private readonly ILogger<Create> _logger;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<BusinessUnitPhoneNumber> _repository;

        public Create(
            IRepository<BusinessUnitPhoneNumber> repository,
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

        [HttpPost("api/businessUnitPhoneNumbers")]
        [SwaggerOperation(
            Summary = "Creates a new BusinessUnitPhoneNumber",
            Description = "Creates a new BusinessUnitPhoneNumber",
            OperationId = "businessUnitPhoneNumbers.create",
            Tags = new[] { "BusinessUnitPhoneNumberEndpoints" })
        ]
        public override async Task<ActionResult<CreateBusinessUnitPhoneNumberResponse>> HandleAsync(
            CreateBusinessUnitPhoneNumberRequest request,
            CancellationToken cancellationToken)

        {
            var response = new CreateBusinessUnitPhoneNumberResponse(request.CorrelationId());

            //var businessUnit = await _businessUnitRepository.GetByIdAsync(request.BusinessUnitId);// parent entity

            var newBusinessUnitPhoneNumber = new BusinessUnitPhoneNumber(
                request.BusinessUnitId,
                request.PhoneNumberId,
                request.PhoneNumberTypeId
            );


            await _repository.AddAsync(newBusinessUnitPhoneNumber);

            _logger.LogInformation(
                $"BusinessUnitPhoneNumber created  with Id {newBusinessUnitPhoneNumber.RowId.ToString("D", CultureInfo.InvariantCulture)}");

            var dto = _mapper.Map<BusinessUnitPhoneNumberDto>(newBusinessUnitPhoneNumber);

            var businessUnitPhoneNumberCreatedEvent =
                new BusinessUnitPhoneNumberCreatedEvent(newBusinessUnitPhoneNumber, "Mongo-History");
            _messagePublisher.Publish(businessUnitPhoneNumberCreatedEvent);

            response.BusinessUnitPhoneNumber = dto;


            return Ok(response);
        }
    }
}