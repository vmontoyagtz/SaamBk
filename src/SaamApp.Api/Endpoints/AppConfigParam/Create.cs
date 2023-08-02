using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SaamApp.BlazorMauiShared.Models.AppConfigParam;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.AppConfigParamEndpoints
{
    public class Create : EndpointBaseAsync.WithRequest<CreateAppConfigParamRequest>.WithActionResult<
        CreateAppConfigParamResponse>
    {
        private readonly ILogger<Create> _logger;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<AppConfigParam> _repository;

        public Create(
            IRepository<AppConfigParam> repository,
            IMapper mapper,
            IApplicationMessagePublisher messagePublisher,
            ILogger<Create> logger
        )
        {
            _mapper = mapper;
            _messagePublisher = messagePublisher;
            _logger = logger;
            _repository = repository;
        }

        [HttpPost("api/appConfigParams")]
        [SwaggerOperation(
            Summary = "Creates a new AppConfigParam",
            Description = "Creates a new AppConfigParam",
            OperationId = "appConfigParams.create",
            Tags = new[] { "AppConfigParamEndpoints" })
        ]
        public override async Task<ActionResult<CreateAppConfigParamResponse>> HandleAsync(
            CreateAppConfigParamRequest request,
            CancellationToken cancellationToken)

        {
            var response = new CreateAppConfigParamResponse(request.CorrelationId());


            var newAppConfigParam = new AppConfigParam(
                Guid.NewGuid(),
                request.AppConfigParamName,
                request.AppConfigParamValue,
                request.AppConfigParamDescription,
                request.CustomerLowBalance,
                request.AppConfigSettingsJson,
                request.CreatedAt,
                request.CreatedBy,
                request.UpdatedAt,
                request.UpdatedBy,
                request.IsDeleted,
                request.TenantId
            );


            await _repository.AddAsync(newAppConfigParam);

            _logger.LogInformation(
                $"AppConfigParam created  with Id {newAppConfigParam.AppConfigParamId.ToString("D", CultureInfo.InvariantCulture)}");

            var dto = _mapper.Map<AppConfigParamDto>(newAppConfigParam);

            var appConfigParamCreatedEvent = new AppConfigParamCreatedEvent(newAppConfigParam, "Mongo-History");
            _messagePublisher.Publish(appConfigParamCreatedEvent);

            response.AppConfigParam = dto;


            return Ok(response);
        }
    }
}