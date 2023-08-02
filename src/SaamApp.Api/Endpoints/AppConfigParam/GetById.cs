using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.AppConfigParam;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.AppConfigParamEndpoints
{
    public class GetById : EndpointBaseAsync.WithRequest<GetByIdAppConfigParamRequest>.WithActionResult<
        GetByIdAppConfigParamResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<AppConfigParam> _repository;

        public GetById(
            IRepository<AppConfigParam> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/appConfigParams/{AppConfigParamId}")]
        [SwaggerOperation(
            Summary = "Get a AppConfigParam by Id",
            Description = "Gets a AppConfigParam by Id",
            OperationId = "appConfigParams.GetById",
            Tags = new[] { "AppConfigParamEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdAppConfigParamResponse>> HandleAsync(
            [FromRoute] GetByIdAppConfigParamRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdAppConfigParamResponse(request.CorrelationId());

            var appConfigParam = await _repository.GetByIdAsync(request.AppConfigParamId);
            if (appConfigParam is null)
            {
                return NotFound();
            }

            response.AppConfigParam = _mapper.Map<AppConfigParamDto>(appConfigParam);

            return Ok(response);
        }
    }
}