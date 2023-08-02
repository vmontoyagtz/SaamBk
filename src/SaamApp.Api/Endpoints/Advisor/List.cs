using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.Advisor;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.AdvisorEndpoints
{
    public class List : EndpointBaseAsync.WithRequest<ListAdvisorRequest>.WithActionResult<ListAdvisorResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Advisor> _repository;

        public List(IRepository<Advisor> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/advisors")]
        [SwaggerOperation(
            Summary = "List Advisors",
            Description = "List Advisors",
            OperationId = "advisors.List",
            Tags = new[] { "AdvisorEndpoints" })
        ]
        public override async Task<ActionResult<ListAdvisorResponse>> HandleAsync(
            [FromQuery] ListAdvisorRequest request,
            CancellationToken cancellationToken)
        {
            var response = new ListAdvisorResponse(request.CorrelationId());

            var spec = new AdvisorGetListSpec();
            var advisors = await _repository.ListAsync(spec);
            if (advisors is null)
            {
                return NotFound();
            }

            response.Advisors = _mapper.Map<List<AdvisorDto>>(advisors);
            response.Count = response.Advisors.Count;

            return Ok(response);
        }
    }
}