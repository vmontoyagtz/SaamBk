using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.AdvisorApplicant;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.AdvisorApplicantEndpoints
{
    public class GetById : EndpointBaseAsync.WithRequest<GetByIdAdvisorApplicantRequest>.WithActionResult<
        GetByIdAdvisorApplicantResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<AdvisorApplicant> _repository;

        public GetById(
            IRepository<AdvisorApplicant> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/advisorApplicants/{AdvisorApplicantId}")]
        [SwaggerOperation(
            Summary = "Get a AdvisorApplicant by Id",
            Description = "Gets a AdvisorApplicant by Id",
            OperationId = "advisorApplicants.GetById",
            Tags = new[] { "AdvisorApplicantEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdAdvisorApplicantResponse>> HandleAsync(
            [FromRoute] GetByIdAdvisorApplicantRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdAdvisorApplicantResponse(request.CorrelationId());

            var advisorApplicant = await _repository.GetByIdAsync(request.AdvisorApplicantId);
            if (advisorApplicant is null)
            {
                return NotFound();
            }

            response.AdvisorApplicant = _mapper.Map<AdvisorApplicantDto>(advisorApplicant);

            return Ok(response);
        }
    }
}