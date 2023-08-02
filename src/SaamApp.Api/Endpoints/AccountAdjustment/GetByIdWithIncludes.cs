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
    public class GetByIdWithIncludes : EndpointBaseAsync.WithRequest<GetByIdAccountAdjustmentRequest>.WithActionResult<
        GetByIdAccountAdjustmentResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<AccountAdjustment> _repository;

        public GetByIdWithIncludes(
            IRepository<AccountAdjustment> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/accountAdjustments/i/{AccountAdjustmentId}")]
        [SwaggerOperation(
            Summary = "Get a AccountAdjustment by Id With Includes",
            Description = "Gets a AccountAdjustment by Id With Includes",
            OperationId = "accountAdjustments.GetByIdWithIncludes",
            Tags = new[] { "AccountAdjustmentEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdAccountAdjustmentResponse>> HandleAsync(
            [FromRoute] GetByIdAccountAdjustmentRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdAccountAdjustmentResponse(request.CorrelationId());

            var spec = new AccountAdjustmentByIdWithIncludesSpec(request.AccountAdjustmentId);

            var accountAdjustment = await _repository.FirstOrDefaultAsync(spec);


            if (accountAdjustment is null)
            {
                return NotFound();
            }

            response.AccountAdjustment = _mapper.Map<AccountAdjustmentDto>(accountAdjustment);

            return Ok(response);
        }
    }
}