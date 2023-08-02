using System.Collections.Generic;
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
    public class List : EndpointBaseAsync.WithRequest<ListDiscountCodeRedemptionRequest>.WithActionResult<
        ListDiscountCodeRedemptionResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<DiscountCodeRedemption> _repository;

        public List(IRepository<DiscountCodeRedemption> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/discountCodeRedemptions")]
        [SwaggerOperation(
            Summary = "List DiscountCodeRedemptions",
            Description = "List DiscountCodeRedemptions",
            OperationId = "discountCodeRedemptions.List",
            Tags = new[] { "DiscountCodeRedemptionEndpoints" })
        ]
        public override async Task<ActionResult<ListDiscountCodeRedemptionResponse>> HandleAsync(
            [FromQuery] ListDiscountCodeRedemptionRequest request,
            CancellationToken cancellationToken)
        {
            var response = new ListDiscountCodeRedemptionResponse(request.CorrelationId());

            var spec = new DiscountCodeRedemptionGetListSpec();
            var discountCodeRedemptions = await _repository.ListAsync(spec);
            if (discountCodeRedemptions is null)
            {
                return NotFound();
            }

            response.DiscountCodeRedemptions = _mapper.Map<List<DiscountCodeRedemptionDto>>(discountCodeRedemptions);
            response.Count = response.DiscountCodeRedemptions.Count;

            return Ok(response);
        }
    }
}