using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.Advisor;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.AdvisorEndpoints
{
    public class GetById : EndpointBaseAsync.WithRequest<GetByIdAdvisorRequest>.WithActionResult<
        GetByIdAdvisorResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Advisor> _repository;

        public GetById(
            IRepository<Advisor> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/advisors/{AdvisorId}")]
        [SwaggerOperation(
            Summary = "Get a Advisor by Id",
            Description = "Gets a Advisor by Id",
            OperationId = "advisors.GetById",
            Tags = new[] { "AdvisorEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdAdvisorResponse>> HandleAsync(
            [FromRoute] GetByIdAdvisorRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdAdvisorResponse(request.CorrelationId());

            var advisor = await _repository.GetByIdAsync(request.AdvisorId);
            if (advisor is null)
            {
                return NotFound();
            }

            response.Advisor = _mapper.Map<AdvisorDto>(advisor);

            return Ok(response);
        }
    }
}