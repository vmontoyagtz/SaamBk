using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SaamApp.BlazorMauiShared.Models.AdvisorBank;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.AdvisorBankEndpoints
{
    public class Create : EndpointBaseAsync.WithRequest<CreateAdvisorBankRequest>.WithActionResult<
        CreateAdvisorBankResponse>
    {
        private readonly IRepository<Advisor> _advisorRepository;

        private readonly ILogger<Create> _logger;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<AdvisorBank> _repository;

        public Create(
            IRepository<AdvisorBank> repository,
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

        [HttpPost("api/advisorBanks")]
        [SwaggerOperation(
            Summary = "Creates a new AdvisorBank",
            Description = "Creates a new AdvisorBank",
            OperationId = "advisorBanks.create",
            Tags = new[] { "AdvisorBankEndpoints" })
        ]
        public override async Task<ActionResult<CreateAdvisorBankResponse>> HandleAsync(
            CreateAdvisorBankRequest request,
            CancellationToken cancellationToken)

        {
            var response = new CreateAdvisorBankResponse(request.CorrelationId());

            //var advisor = await _advisorRepository.GetByIdAsync(request.AdvisorId);// parent entity

            var newAdvisorBank = new AdvisorBank(
                request.AdvisorId,
                request.BankAccountId,
                request.IsDefault
            );


            await _repository.AddAsync(newAdvisorBank);

            _logger.LogInformation(
                $"AdvisorBank created  with Id {newAdvisorBank.RowId.ToString("D", CultureInfo.InvariantCulture)}");

            var dto = _mapper.Map<AdvisorBankDto>(newAdvisorBank);

            var advisorBankCreatedEvent = new AdvisorBankCreatedEvent(newAdvisorBank, "Mongo-History");
            _messagePublisher.Publish(advisorBankCreatedEvent);

            response.AdvisorBank = dto;


            return Ok(response);
        }
    }
}