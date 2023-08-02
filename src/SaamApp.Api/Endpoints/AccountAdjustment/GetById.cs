using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.AccountAdjustment;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.AccountAdjustmentEndpoints
{
    public class GetById : EndpointBaseAsync.WithRequest<GetByIdAccountAdjustmentRequest>.WithActionResult<
        GetByIdAccountAdjustmentResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<AccountAdjustment> _repository;

        public GetById(
            IRepository<AccountAdjustment> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/accountAdjustments/{AccountAdjustmentId}")]
        [SwaggerOperation(
            Summary = "Get a AccountAdjustment by Id",
            Description = "Gets a AccountAdjustment by Id",
            OperationId = "accountAdjustments.GetById",
            Tags = new[] { "AccountAdjustmentEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdAccountAdjustmentResponse>> HandleAsync(
            [FromRoute] GetByIdAccountAdjustmentRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdAccountAdjustmentResponse(request.CorrelationId());

            var accountAdjustment = await _repository.GetByIdAsync(request.AccountAdjustmentId);
            if (accountAdjustment is null)
            {
                return NotFound();
            }

            response.AccountAdjustment = _mapper.Map<AccountAdjustmentDto>(accountAdjustment);

            return Ok(response);
        }
    }
}