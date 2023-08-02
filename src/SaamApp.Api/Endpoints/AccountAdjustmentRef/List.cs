using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.AccountAdjustmentRef;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.AccountAdjustmentRefEndpoints
{
    public class List : EndpointBaseAsync.WithRequest<ListAccountAdjustmentRefRequest>.WithActionResult<
        ListAccountAdjustmentRefResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<AccountAdjustmentRef> _repository;

        public List(IRepository<AccountAdjustmentRef> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/accountAdjustmentRefs")]
        [SwaggerOperation(
            Summary = "List AccountAdjustmentRefs",
            Description = "List AccountAdjustmentRefs",
            OperationId = "accountAdjustmentRefs.List",
            Tags = new[] { "AccountAdjustmentRefEndpoints" })
        ]
        public override async Task<ActionResult<ListAccountAdjustmentRefResponse>> HandleAsync(
            [FromQuery] ListAccountAdjustmentRefRequest request,
            CancellationToken cancellationToken)
        {
            var response = new ListAccountAdjustmentRefResponse(request.CorrelationId());

            var spec = new AccountAdjustmentRefGetListSpec();
            var accountAdjustmentRefs = await _repository.ListAsync(spec);
            if (accountAdjustmentRefs is null)
            {
                return NotFound();
            }

            response.AccountAdjustmentRefs = _mapper.Map<List<AccountAdjustmentRefDto>>(accountAdjustmentRefs);
            response.Count = response.AccountAdjustmentRefs.Count;

            return Ok(response);
        }
    }
}