using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.AdvisorBank;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.AdvisorBankEndpoints
{
    public class GetById : EndpointBaseAsync.WithRequest<GetByIdAdvisorBankRequest>.WithActionResult<
        GetByIdAdvisorBankResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<AdvisorBank> _repository;

        public GetById(
            IRepository<AdvisorBank> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/advisorBanks/{RowId}")]
        [SwaggerOperation(
            Summary = "Get a AdvisorBank by Id",
            Description = "Gets a AdvisorBank by Id",
            OperationId = "advisorBanks.GetById",
            Tags = new[] { "AdvisorBankEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdAdvisorBankResponse>> HandleAsync(
            [FromRoute] GetByIdAdvisorBankRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdAdvisorBankResponse(request.CorrelationId());

            var advisorBank = await _repository.GetByIdAsync(request.RowId);
            if (advisorBank is null)
            {
                return NotFound();
            }

            response.AdvisorBank = _mapper.Map<AdvisorBankDto>(advisorBank);

            return Ok(response);
        }
    }
}