using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.AdvisorBank;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.AdvisorBankEndpoints
{
    public class GetByRelsIds : EndpointBaseAsync.WithRequest<GetByRelsIdsAdvisorBankRequest>.WithActionResult<
        GetByIdAdvisorBankResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<AdvisorBank> _repository;

        public GetByRelsIds(
            IRepository<AdvisorBank> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/advisorBanks/{IsDefault}/{AdvisorId}/{BankAccountId}")]
        [SwaggerOperation(
            Summary = "Get a AdvisorBank by rel Ids",
            Description = "Gets a AdvisorBank by rel Ids",
            OperationId = "advisorBanks.GetByRelsIds",
            Tags = new[] { "AdvisorBankEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdAdvisorBankResponse>> HandleAsync(
            [FromRoute] GetByRelsIdsAdvisorBankRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdAdvisorBankResponse(request.CorrelationId());

            var spec = new AdvisorBankByRelIdsSpec(request.IsDefault, request.AdvisorId, request.BankAccountId);

            var advisorBank = await _repository.FirstOrDefaultAsync(spec);


            if (advisorBank is null)
            {
                return NotFound();
            }

            response.AdvisorBank = _mapper.Map<AdvisorBankDto>(advisorBank);

            return Ok(response);
        }
    }
}