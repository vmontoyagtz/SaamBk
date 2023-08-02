using System.Collections.Generic;
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
    public class List : EndpointBaseAsync.WithRequest<ListGiftCodeRedemptionRequest>.WithActionResult<
        ListGiftCodeRedemptionResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<GiftCodeRedemption> _repository;

        public List(IRepository<GiftCodeRedemption> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/giftCodeRedemptions")]
        [SwaggerOperation(
            Summary = "List GiftCodeRedemptions",
            Description = "List GiftCodeRedemptions",
            OperationId = "giftCodeRedemptions.List",
            Tags = new[] { "GiftCodeRedemptionEndpoints" })
        ]
        public override async Task<ActionResult<ListGiftCodeRedemptionResponse>> HandleAsync(
            [FromQuery] ListGiftCodeRedemptionRequest request,
            CancellationToken cancellationToken)
        {
            var response = new ListGiftCodeRedemptionResponse(request.CorrelationId());

            var spec = new GiftCodeRedemptionGetListSpec();
            var giftCodeRedemptions = await _repository.ListAsync(spec);
            if (giftCodeRedemptions is null)
            {
                return NotFound();
            }

            response.GiftCodeRedemptions = _mapper.Map<List<GiftCodeRedemptionDto>>(giftCodeRedemptions);
            response.Count = response.GiftCodeRedemptions.Count;

            return Ok(response);
        }
    }
}