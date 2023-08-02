using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.AccountAdjustment;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.AccountAdjustmentEndpoints
{
    public class List : EndpointBaseAsync.WithRequest<ListAccountAdjustmentRequest>.WithActionResult<
        ListAccountAdjustmentResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<AccountAdjustment> _repository;

        public List(IRepository<AccountAdjustment> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/accountAdjustments")]
        [SwaggerOperation(
            Summary = "List AccountAdjustments",
            Description = "List AccountAdjustments",
            OperationId = "accountAdjustments.List",
            Tags = new[] { "AccountAdjustmentEndpoints" })
        ]
        public override async Task<ActionResult<ListAccountAdjustmentResponse>> HandleAsync(
            [FromQuery] ListAccountAdjustmentRequest request,
            CancellationToken cancellationToken)
        {
            var response = new ListAccountAdjustmentResponse(request.CorrelationId());

            var spec = new AccountAdjustmentGetListSpec();
            var accountAdjustments = await _repository.ListAsync(spec);
            if (accountAdjustments is null)
            {
                return NotFound();
            }

            response.AccountAdjustments = _mapper.Map<List<AccountAdjustmentDto>>(accountAdjustments);
            response.Count = response.AccountAdjustments.Count;

            return Ok(response);
        }
    }
}