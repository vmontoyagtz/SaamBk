using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.AppConfigParam;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace BusinessManagement.Api.AppConfigParamEndpoints
{
    public class Update : EndpointBaseAsync.WithRequest<UpdateAppConfigParamRequest>.WithActionResult<
        UpdateAppConfigParamResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<AppConfigParam> _repository;

        public Update(
            IRepository<AppConfigParam> repository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPut("api/appConfigParams")]
        [SwaggerOperation(
            Summary = "Updates a AppConfigParam",
            Description = "Updates a AppConfigParam",
            OperationId = "appConfigParams.update",
            Tags = new[] { "AppConfigParamEndpoints" })
        ]
        public override async Task<ActionResult<UpdateAppConfigParamResponse>> HandleAsync(
            UpdateAppConfigParamRequest request, CancellationToken cancellationToken)
        {
            var response = new UpdateAppConfigParamResponse(request.CorrelationId());

            var acppcppcpToUpdate = _mapper.Map<AppConfigParam>(request);

            var appConfigParamToUpdateTest = await _repository.GetByIdAsync(request.AppConfigParamId);
            if (appConfigParamToUpdateTest is null)
            {
                return NotFound();
            }

            await _repository.UpdateAsync(acppcppcpToUpdate);

            var appConfigParamUpdatedEvent = new AppConfigParamUpdatedEvent(acppcppcpToUpdate, "Mongo-History");
            _messagePublisher.Publish(appConfigParamUpdatedEvent);

            var dto = _mapper.Map<AppConfigParamDto>(acppcppcpToUpdate);
            response.AppConfigParam = dto;

            return Ok(response);
        }
    }
}