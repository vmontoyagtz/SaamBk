using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.AdvisorApplicant;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.AdvisorApplicantEndpoints
{
    public class GetByIdWithIncludes : EndpointBaseAsync.WithRequest<GetByIdAdvisorApplicantRequest>.WithActionResult<
        GetByIdAdvisorApplicantResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<AdvisorApplicant> _repository;

        public GetByIdWithIncludes(
            IRepository<AdvisorApplicant> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/advisorApplicants/i/{AdvisorApplicantId}")]
        [SwaggerOperation(
            Summary = "Get a AdvisorApplicant by Id With Includes",
            Description = "Gets a AdvisorApplicant by Id With Includes",
            OperationId = "advisorApplicants.GetByIdWithIncludes",
            Tags = new[] { "AdvisorApplicantEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdAdvisorApplicantResponse>> HandleAsync(
            [FromRoute] GetByIdAdvisorApplicantRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdAdvisorApplicantResponse(request.CorrelationId());

            var spec = new AdvisorApplicantByIdWithIncludesSpec(request.AdvisorApplicantId);

            var advisorApplicant = await _repository.FirstOrDefaultAsync(spec);


            if (advisorApplicant is null)
            {
                return NotFound();
            }

            response.AdvisorApplicant = _mapper.Map<AdvisorApplicantDto>(advisorApplicant);

            return Ok(response);
        }
    }
}