using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.PrepaidPackageRedemption;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.PrepaidPackageRedemptionEndpoints
{
    public class GetById : EndpointBaseAsync.WithRequest<GetByIdPrepaidPackageRedemptionRequest>.WithActionResult<
        GetByIdPrepaidPackageRedemptionResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<PrepaidPackageRedemption> _repository;

        public GetById(
            IRepository<PrepaidPackageRedemption> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/prepaidPackageRedemptions/{PrepaidPackageRedemptionId}")]
        [SwaggerOperation(
            Summary = "Get a PrepaidPackageRedemption by Id",
            Description = "Gets a PrepaidPackageRedemption by Id",
            OperationId = "prepaidPackageRedemptions.GetById",
            Tags = new[] { "PrepaidPackageRedemptionEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdPrepaidPackageRedemptionResponse>> HandleAsync(
            [FromRoute] GetByIdPrepaidPackageRedemptionRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdPrepaidPackageRedemptionResponse(request.CorrelationId());

            var prepaidPackageRedemption = await _repository.GetByIdAsync(request.PrepaidPackageRedemptionId);
            if (prepaidPackageRedemption is null)
            {
                return NotFound();
            }

            response.PrepaidPackageRedemption = _mapper.Map<PrepaidPackageRedemptionDto>(prepaidPackageRedemption);

            return Ok(response);
        }
    }
}