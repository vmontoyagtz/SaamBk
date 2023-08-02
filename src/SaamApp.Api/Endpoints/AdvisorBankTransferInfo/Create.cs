using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SaamApp.BlazorMauiShared.Models.AdvisorBankTransferInfo;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.AdvisorBankTransferInfoEndpoints
{
    public class Create : EndpointBaseAsync.WithRequest<CreateAdvisorBankTransferInfoRequest>.WithActionResult<
        CreateAdvisorBankTransferInfoResponse>
    {
        private readonly IRepository<Advisor> _advisorRepository;

        private readonly ILogger<Create> _logger;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<AdvisorBankTransferInfo> _repository;

        public Create(
            IRepository<AdvisorBankTransferInfo> repository,
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

        [HttpPost("api/advisorBankTransferInfoes")]
        [SwaggerOperation(
            Summary = "Creates a new AdvisorBankTransferInfo",
            Description = "Creates a new AdvisorBankTransferInfo",
            OperationId = "advisorBankTransferInfoes.create",
            Tags = new[] { "AdvisorBankTransferInfoEndpoints" })
        ]
        public override async Task<ActionResult<CreateAdvisorBankTransferInfoResponse>> HandleAsync(
            CreateAdvisorBankTransferInfoRequest request,
            CancellationToken cancellationToken)

        {
            var response = new CreateAdvisorBankTransferInfoResponse(request.CorrelationId());

            //var advisor = await _advisorRepository.GetByIdAsync(request.AdvisorId);// parent entity

            var newAdvisorBankTransferInfo = new AdvisorBankTransferInfo(
                Guid.NewGuid(),
                request.AdvisorId,
                request.BankAccountId,
                request.BankTransferNotes,
                request.CreatedAt,
                request.CreatedBy,
                request.UpdatedAt,
                request.UpdatedBy,
                request.IsDeleted
            );


            await _repository.AddAsync(newAdvisorBankTransferInfo);

            _logger.LogInformation(
                $"AdvisorBankTransferInfo created  with Id {newAdvisorBankTransferInfo.AdvisorBankTransferInfoId.ToString("D", CultureInfo.InvariantCulture)}");

            var dto = _mapper.Map<AdvisorBankTransferInfoDto>(newAdvisorBankTransferInfo);

            var advisorBankTransferInfoCreatedEvent =
                new AdvisorBankTransferInfoCreatedEvent(newAdvisorBankTransferInfo, "Mongo-History");
            _messagePublisher.Publish(advisorBankTransferInfoCreatedEvent);

            response.AdvisorBankTransferInfo = dto;


            return Ok(response);
        }
    }
}