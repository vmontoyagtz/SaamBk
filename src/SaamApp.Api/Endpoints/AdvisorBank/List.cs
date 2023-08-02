using System.Collections.Generic;
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
    public class List : EndpointBaseAsync.WithRequest<ListAdvisorBankRequest>.WithActionResult<ListAdvisorBankResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<AdvisorBank> _repository;

        public List(IRepository<AdvisorBank> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/advisorBanks")]
        [SwaggerOperation(
            Summary = "List AdvisorBanks",
            Description = "List AdvisorBanks",
            OperationId = "advisorBanks.List",
            Tags = new[] { "AdvisorBankEndpoints" })
        ]
        public override async Task<ActionResult<ListAdvisorBankResponse>> HandleAsync(
            [FromQuery] ListAdvisorBankRequest request,
            CancellationToken cancellationToken)
        {
            var response = new ListAdvisorBankResponse(request.CorrelationId());

            var spec = new AdvisorBankGetListSpec();
            var advisorBanks = await _repository.ListAsync(spec);
            if (advisorBanks is null)
            {
                return NotFound();
            }

            response.AdvisorBanks = _mapper.Map<List<AdvisorBankDto>>(advisorBanks);
            response.Count = response.AdvisorBanks.Count;

            return Ok(response);
        }
    }
}