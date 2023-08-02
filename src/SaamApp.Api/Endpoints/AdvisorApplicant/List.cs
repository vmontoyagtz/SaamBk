using System.Collections.Generic;
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
    public class List : EndpointBaseAsync.WithRequest<ListAdvisorApplicantRequest>.WithActionResult<
        ListAdvisorApplicantResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<AdvisorApplicant> _repository;

        public List(IRepository<AdvisorApplicant> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/advisorApplicants")]
        [SwaggerOperation(
            Summary = "List AdvisorApplicants",
            Description = "List AdvisorApplicants",
            OperationId = "advisorApplicants.List",
            Tags = new[] { "AdvisorApplicantEndpoints" })
        ]
        public override async Task<ActionResult<ListAdvisorApplicantResponse>> HandleAsync(
            [FromQuery] ListAdvisorApplicantRequest request,
            CancellationToken cancellationToken)
        {
            var response = new ListAdvisorApplicantResponse(request.CorrelationId());

            var spec = new AdvisorApplicantGetListSpec();
            var advisorApplicants = await _repository.ListAsync(spec);
            if (advisorApplicants is null)
            {
                return NotFound();
            }

            response.AdvisorApplicants = _mapper.Map<List<AdvisorApplicantDto>>(advisorApplicants);
            response.Count = response.AdvisorApplicants.Count;

            return Ok(response);
        }
    }
}