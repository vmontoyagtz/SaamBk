using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SaamApp.BlazorMauiShared.Models.AdvisorEmailAddress;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.AdvisorEmailAddressEndpoints
{
    public class Create : EndpointBaseAsync.WithRequest<CreateAdvisorEmailAddressRequest>.WithActionResult<
        CreateAdvisorEmailAddressResponse>
    {
        private readonly IRepository<Advisor> _advisorRepository;

        private readonly ILogger<Create> _logger;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<AdvisorEmailAddress> _repository;

        public Create(
            IRepository<AdvisorEmailAddress> repository,
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

        [HttpPost("api/advisorEmailAddresses")]
        [SwaggerOperation(
            Summary = "Creates a new AdvisorEmailAddress",
            Description = "Creates a new AdvisorEmailAddress",
            OperationId = "advisorEmailAddresses.create",
            Tags = new[] { "AdvisorEmailAddressEndpoints" })
        ]
        public override async Task<ActionResult<CreateAdvisorEmailAddressResponse>> HandleAsync(
            CreateAdvisorEmailAddressRequest request,
            CancellationToken cancellationToken)

        {
            var response = new CreateAdvisorEmailAddressResponse(request.CorrelationId());

            //var advisor = await _advisorRepository.GetByIdAsync(request.AdvisorId);// parent entity

            var newAdvisorEmailAddress = new AdvisorEmailAddress(
                request.AdvisorId,
                request.EmailAddressId,
                request.EmailAddressTypeId
            );


            await _repository.AddAsync(newAdvisorEmailAddress);

            _logger.LogInformation(
                $"AdvisorEmailAddress created  with Id {newAdvisorEmailAddress.RowId.ToString("D", CultureInfo.InvariantCulture)}");

            var dto = _mapper.Map<AdvisorEmailAddressDto>(newAdvisorEmailAddress);

            var advisorEmailAddressCreatedEvent =
                new AdvisorEmailAddressCreatedEvent(newAdvisorEmailAddress, "Mongo-History");
            _messagePublisher.Publish(advisorEmailAddressCreatedEvent);

            response.AdvisorEmailAddress = dto;


            return Ok(response);
        }
    }
}