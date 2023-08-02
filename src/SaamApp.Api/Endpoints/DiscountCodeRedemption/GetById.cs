using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.DiscountCodeRedemption;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.DiscountCodeRedemptionEndpoints
{
    public class GetById : EndpointBaseAsync.WithRequest<GetByIdDiscountCodeRedemptionRequest>.WithActionResult<
        GetByIdDiscountCodeRedemptionResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<DiscountCodeRedemption> _repository;

        public GetById(
            IRepository<DiscountCodeRedemption> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/discountCodeRedemptions/{RowId}")]
        [SwaggerOperation(
            Summary = "Get a DiscountCodeRedemption by Id",
            Description = "Gets a DiscountCodeRedemption by Id",
            OperationId = "discountCodeRedemptions.GetById",
            Tags = new[] { "DiscountCodeRedemptionEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdDiscountCodeRedemptionResponse>> HandleAsync(
            [FromRoute] GetByIdDiscountCodeRedemptionRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdDiscountCodeRedemptionResponse(request.CorrelationId());

            var discountCodeRedemption = await _repository.GetByIdAsync(request.RowId);
            if (discountCodeRedemption is null)
            {
                return NotFound();
            }

            response.DiscountCodeRedemption = _mapper.Map<DiscountCodeRedemptionDto>(discountCodeRedemption);

            return Ok(response);
        }
    }
}