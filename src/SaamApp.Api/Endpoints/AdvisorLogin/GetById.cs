using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.AdvisorLogin;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.AdvisorLoginEndpoints
{
    public class GetById : EndpointBaseAsync.WithRequest<GetByIdAdvisorLoginRequest>.WithActionResult<
        GetByIdAdvisorLoginResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<AdvisorLogin> _repository;

        public GetById(
            IRepository<AdvisorLogin> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/advisorLogins/{AdvisorLoginId}")]
        [SwaggerOperation(
            Summary = "Get a AdvisorLogin by Id",
            Description = "Gets a AdvisorLogin by Id",
            OperationId = "advisorLogins.GetById",
            Tags = new[] { "AdvisorLoginEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdAdvisorLoginResponse>> HandleAsync(
            [FromRoute] GetByIdAdvisorLoginRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdAdvisorLoginResponse(request.CorrelationId());

            var advisorLogin = await _repository.GetByIdAsync(request.AdvisorLoginId);
            if (advisorLogin is null)
            {
                return NotFound();
            }

            response.AdvisorLogin = _mapper.Map<AdvisorLoginDto>(advisorLogin);

            return Ok(response);
        }
    }
}