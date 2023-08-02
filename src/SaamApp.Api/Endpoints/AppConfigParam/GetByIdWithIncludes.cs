using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.AppConfigParam;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.AppConfigParamEndpoints
{
    public class GetByIdWithIncludes : EndpointBaseAsync.WithRequest<GetByIdAppConfigParamRequest>.WithActionResult<
        GetByIdAppConfigParamResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<AppConfigParam> _repository;

        public GetByIdWithIncludes(
            IRepository<AppConfigParam> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/appConfigParams/i/{AppConfigParamId}")]
        [SwaggerOperation(
            Summary = "Get a AppConfigParam by Id With Includes",
            Description = "Gets a AppConfigParam by Id With Includes",
            OperationId = "appConfigParams.GetByIdWithIncludes",
            Tags = new[] { "AppConfigParamEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdAppConfigParamResponse>> HandleAsync(
            [FromRoute] GetByIdAppConfigParamRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdAppConfigParamResponse(request.CorrelationId());

            var spec = new AppConfigParamByIdWithIncludesSpec(request.AppConfigParamId);

            var appConfigParam = await _repository.FirstOrDefaultAsync(spec);


            if (appConfigParam is null)
            {
                return NotFound();
            }

            response.AppConfigParam = _mapper.Map<AppConfigParamDto>(appConfigParam);

            return Ok(response);
        }
    }
}