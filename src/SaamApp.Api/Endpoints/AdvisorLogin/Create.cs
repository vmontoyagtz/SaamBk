using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SaamApp.BlazorMauiShared.Models.AdvisorLogin;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.AdvisorLoginEndpoints
{
    public class Create : EndpointBaseAsync.WithRequest<CreateAdvisorLoginRequest>.WithActionResult<
        CreateAdvisorLoginResponse>
    {
        private readonly IRepository<Advisor> _advisorRepository;

        private readonly ILogger<Create> _logger;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<AdvisorLogin> _repository;

        public Create(
            IRepository<AdvisorLogin> repository,
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

        [HttpPost("api/advisorLogins")]
        [SwaggerOperation(
            Summary = "Creates a new AdvisorLogin",
            Description = "Creates a new AdvisorLogin",
            OperationId = "advisorLogins.create",
            Tags = new[] { "AdvisorLoginEndpoints" })
        ]
        public override async Task<ActionResult<CreateAdvisorLoginResponse>> HandleAsync(
            CreateAdvisorLoginRequest request,
            CancellationToken cancellationToken)

        {
            var response = new CreateAdvisorLoginResponse(request.CorrelationId());

            //var advisor = await _advisorRepository.GetByIdAsync(request.AdvisorId);// parent entity

            var newAdvisorLogin = new AdvisorLogin(
                Guid.NewGuid(),
                request.AdvisorId,
                request.AdvisorLoginDateTime,
                request.AdvisorLoginStage
            );


            await _repository.AddAsync(newAdvisorLogin);

            _logger.LogInformation(
                $"AdvisorLogin created  with Id {newAdvisorLogin.AdvisorLoginId.ToString("D", CultureInfo.InvariantCulture)}");

            var dto = _mapper.Map<AdvisorLoginDto>(newAdvisorLogin);

            var advisorLoginCreatedEvent = new AdvisorLoginCreatedEvent(newAdvisorLogin, "Mongo-History");
            _messagePublisher.Publish(advisorLoginCreatedEvent);

            response.AdvisorLogin = dto;


            return Ok(response);
        }
    }
}