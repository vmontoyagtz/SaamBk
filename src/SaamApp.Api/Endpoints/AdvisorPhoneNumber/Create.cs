using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SaamApp.BlazorMauiShared.Models.AdvisorPhoneNumber;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.AdvisorPhoneNumberEndpoints
{
    public class Create : EndpointBaseAsync.WithRequest<CreateAdvisorPhoneNumberRequest>.WithActionResult<
        CreateAdvisorPhoneNumberResponse>
    {
        private readonly IRepository<Advisor> _advisorRepository;

        private readonly ILogger<Create> _logger;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<AdvisorPhoneNumber> _repository;

        public Create(
            IRepository<AdvisorPhoneNumber> repository,
            IRepository<Advisor> advisorRepository,
            IMapper mapper,
            IApplicationMessagePublisher messagePublisher,
            ILogger<Create> logger
        )
        {
            _mapper = mapper;
            _messagePublisher = messagePublisher;
            _logger = logger;
            _repository = repository;
            _advisorRepository = advisorRepository;
        }

        [HttpPost("api/advisorPhoneNumbers")]
        [SwaggerOperation(
            Summary = "Creates a new AdvisorPhoneNumber",
            Description = "Creates a new AdvisorPhoneNumber",
            OperationId = "advisorPhoneNumbers.create",
            Tags = new[] { "AdvisorPhoneNumberEndpoints" })
        ]
        public override async Task<ActionResult<CreateAdvisorPhoneNumberResponse>> HandleAsync(
            CreateAdvisorPhoneNumberRequest request,
            CancellationToken cancellationToken)

        {
            var response = new CreateAdvisorPhoneNumberResponse(request.CorrelationId());

            //var advisor = await _advisorRepository.GetByIdAsync(request.AdvisorId);// parent entity

            var newAdvisorPhoneNumber = new AdvisorPhoneNumber(
                request.AdvisorId,
                request.PhoneNumberId,
                request.PhoneNumberTypeId
            );


            await _repository.AddAsync(newAdvisorPhoneNumber);

            _logger.LogInformation(
                $"AdvisorPhoneNumber created  with Id {newAdvisorPhoneNumber.RowId.ToString("D", CultureInfo.InvariantCulture)}");

            var dto = _mapper.Map<AdvisorPhoneNumberDto>(newAdvisorPhoneNumber);

            var advisorPhoneNumberCreatedEvent =
                new AdvisorPhoneNumberCreatedEvent(newAdvisorPhoneNumber, "Mongo-History");
            _messagePublisher.Publish(advisorPhoneNumberCreatedEvent);

            response.AdvisorPhoneNumber = dto;


            return Ok(response);
        }
    }
}