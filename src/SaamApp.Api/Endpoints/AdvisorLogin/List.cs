using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.AdvisorLogin;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.AdvisorLoginEndpoints
{
    public class List : EndpointBaseAsync.WithRequest<ListAdvisorLoginRequest>.WithActionResult<
        ListAdvisorLoginResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<AdvisorLogin> _repository;

        public List(IRepository<AdvisorLogin> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/advisorLogins")]
        [SwaggerOperation(
            Summary = "List AdvisorLogins",
            Description = "List AdvisorLogins",
            OperationId = "advisorLogins.List",
            Tags = new[] { "AdvisorLoginEndpoints" })
        ]
        public override async Task<ActionResult<ListAdvisorLoginResponse>> HandleAsync(
            [FromQuery] ListAdvisorLoginRequest request,
            CancellationToken cancellationToken)
        {
            var response = new ListAdvisorLoginResponse(request.CorrelationId());

            var spec = new AdvisorLoginGetListSpec();
            var advisorLogins = await _repository.ListAsync(spec);
            if (advisorLogins is null)
            {
                return NotFound();
            }

            response.AdvisorLogins = _mapper.Map<List<AdvisorLoginDto>>(advisorLogins);
            response.Count = response.AdvisorLogins.Count;

            return Ok(response);
        }
    }
}