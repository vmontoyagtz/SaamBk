using System.Collections.Generic;
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
    public class List : EndpointBaseAsync.WithRequest<ListAppConfigParamRequest>.WithActionResult<
        ListAppConfigParamResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<AppConfigParam> _repository;

        public List(IRepository<AppConfigParam> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/appConfigParams")]
        [SwaggerOperation(
            Summary = "List AppConfigParams",
            Description = "List AppConfigParams",
            OperationId = "appConfigParams.List",
            Tags = new[] { "AppConfigParamEndpoints" })
        ]
        public override async Task<ActionResult<ListAppConfigParamResponse>> HandleAsync(
            [FromQuery] ListAppConfigParamRequest request,
            CancellationToken cancellationToken)
        {
            var response = new ListAppConfigParamResponse(request.CorrelationId());

            var spec = new AppConfigParamGetListSpec();
            var appConfigParams = await _repository.ListAsync(spec);
            if (appConfigParams is null)
            {
                return NotFound();
            }

            response.AppConfigParams = _mapper.Map<List<AppConfigParamDto>>(appConfigParams);
            response.Count = response.AppConfigParams.Count;

            return Ok(response);
        }
    }
}