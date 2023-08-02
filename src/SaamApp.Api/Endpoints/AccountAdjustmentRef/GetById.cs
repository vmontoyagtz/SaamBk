using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.AccountAdjustmentRef;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.AccountAdjustmentRefEndpoints
{
    public class GetById : EndpointBaseAsync.WithRequest<GetByIdAccountAdjustmentRefRequest>.WithActionResult<
        GetByIdAccountAdjustmentRefResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<AccountAdjustmentRef> _repository;

        public GetById(
            IRepository<AccountAdjustmentRef> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/accountAdjustmentRefs/{AccountAdjustmentRefId}")]
        [SwaggerOperation(
            Summary = "Get a AccountAdjustmentRef by Id",
            Description = "Gets a AccountAdjustmentRef by Id",
            OperationId = "accountAdjustmentRefs.GetById",
            Tags = new[] { "AccountAdjustmentRefEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdAccountAdjustmentRefResponse>> HandleAsync(
            [FromRoute] GetByIdAccountAdjustmentRefRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdAccountAdjustmentRefResponse(request.CorrelationId());

            var accountAdjustmentRef = await _repository.GetByIdAsync(request.AccountAdjustmentRefId);
            if (accountAdjustmentRef is null)
            {
                return NotFound();
            }

            response.AccountAdjustmentRef = _mapper.Map<AccountAdjustmentRefDto>(accountAdjustmentRef);

            return Ok(response);
        }
    }
}