using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.DiscountCodeRedemption;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.DiscountCodeRedemptionEndpoints
{
    public class GetByRelsIds : EndpointBaseAsync.WithRequest<GetByRelsIdsDiscountCodeRedemptionRequest>.
        WithActionResult<
            GetByIdDiscountCodeRedemptionResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<DiscountCodeRedemption> _repository;

        public GetByRelsIds(
            IRepository<DiscountCodeRedemption> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/discountCodeRedemptions/{DiscountCodeRedemptionDate}/{CustomerId}/{DiscountCodeId}")]
        [SwaggerOperation(
            Summary = "Get a DiscountCodeRedemption by rel Ids",
            Description = "Gets a DiscountCodeRedemption by rel Ids",
            OperationId = "discountCodeRedemptions.GetByRelsIds",
            Tags = new[] { "DiscountCodeRedemptionEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdDiscountCodeRedemptionResponse>> HandleAsync(
            [FromRoute] GetByRelsIdsDiscountCodeRedemptionRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdDiscountCodeRedemptionResponse(request.CorrelationId());

            var spec = new DiscountCodeRedemptionByRelIdsSpec(request.DiscountCodeRedemptionDate, request.CustomerId,
                request.DiscountCodeId);

            var discountCodeRedemption = await _repository.FirstOrDefaultAsync(spec);


            if (discountCodeRedemption is null)
            {
                return NotFound();
            }

            response.DiscountCodeRedemption = _mapper.Map<DiscountCodeRedemptionDto>(discountCodeRedemption);

            return Ok(response);
        }
    }
}