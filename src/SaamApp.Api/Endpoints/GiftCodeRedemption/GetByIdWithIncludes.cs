using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.GiftCodeRedemption;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.GiftCodeRedemptionEndpoints
{
    public class GetByIdWithIncludes : EndpointBaseAsync.WithRequest<GetByIdGiftCodeRedemptionRequest>.WithActionResult<
        GetByIdGiftCodeRedemptionResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<GiftCodeRedemption> _repository;

        public GetByIdWithIncludes(
            IRepository<GiftCodeRedemption> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/giftCodeRedemptions/i/{GiftCodeRedemptionId}")]
        [SwaggerOperation(
            Summary = "Get a GiftCodeRedemption by Id With Includes",
            Description = "Gets a GiftCodeRedemption by Id With Includes",
            OperationId = "giftCodeRedemptions.GetByIdWithIncludes",
            Tags = new[] { "GiftCodeRedemptionEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdGiftCodeRedemptionResponse>> HandleAsync(
            [FromRoute] GetByIdGiftCodeRedemptionRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdGiftCodeRedemptionResponse(request.CorrelationId());

            var spec = new GiftCodeRedemptionByIdWithIncludesSpec(request.GiftCodeRedemptionId);

            var giftCodeRedemption = await _repository.FirstOrDefaultAsync(spec);


            if (giftCodeRedemption is null)
            {
                return NotFound();
            }

            response.GiftCodeRedemption = _mapper.Map<GiftCodeRedemptionDto>(giftCodeRedemption);

            return Ok(response);
        }
    }
}