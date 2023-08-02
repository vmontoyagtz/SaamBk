using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.AppConfigParam;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.AppConfigParamEndpoints
{
    public class Delete : EndpointBaseAsync.WithRequest<DeleteAppConfigParamRequest>.WithActionResult<
        DeleteAppConfigParamResponse>
    {
        private readonly IRepository<AppConfigParam> _appConfigParamReadRepository;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<AppConfigParam> _repository;

        public Delete(IRepository<AppConfigParam> AppConfigParamRepository,
            IRepository<AppConfigParam> AppConfigParamReadRepository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = AppConfigParamRepository;
            _appConfigParamReadRepository = AppConfigParamReadRepository;
            _mapper = mapper;
        }

        [HttpDelete("api/appConfigParams/{AppConfigParamId}")]
        [SwaggerOperation(
            Summary = "Deletes an AppConfigParam",
            Description = "Deletes an AppConfigParam",
            OperationId = "appConfigParams.delete",
            Tags = new[] { "AppConfigParamEndpoints" })
        ]
        public override async Task<ActionResult<DeleteAppConfigParamResponse>> HandleAsync(
            [FromRoute] DeleteAppConfigParamRequest request, CancellationToken cancellationToken)
        {
            var response = new DeleteAppConfigParamResponse(request.CorrelationId());

            var appConfigParam = await _appConfigParamReadRepository.GetByIdAsync(request.AppConfigParamId);

            if (appConfigParam == null)
            {
                return NotFound();
            }


            var appConfigParamDeletedEvent = new AppConfigParamDeletedEvent(appConfigParam, "Mongo-History");
            _messagePublisher.Publish(appConfigParamDeletedEvent);

            await _repository.DeleteAsync(appConfigParam);

            return Ok(response);
        }
    }
}