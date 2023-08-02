using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.DiscountCode;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.DiscountCodeEndpoints
{
    public class List : EndpointBaseAsync.WithRequest<ListDiscountCodeRequest>.WithActionResult<
        ListDiscountCodeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<DiscountCode> _repository;

        public List(IRepository<DiscountCode> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/discountCodes")]
        [SwaggerOperation(
            Summary = "List DiscountCodes",
            Description = "List DiscountCodes",
            OperationId = "discountCodes.List",
            Tags = new[] { "DiscountCodeEndpoints" })
        ]
        public override async Task<ActionResult<ListDiscountCodeResponse>> HandleAsync(
            [FromQuery] ListDiscountCodeRequest request,
            CancellationToken cancellationToken)
        {
            var response = new ListDiscountCodeResponse(request.CorrelationId());

            var spec = new DiscountCodeGetListSpec();
            var discountCodes = await _repository.ListAsync(spec);
            if (discountCodes is null)
            {
                return NotFound();
            }

            response.DiscountCodes = _mapper.Map<List<DiscountCodeDto>>(discountCodes);
            response.Count = response.DiscountCodes.Count;

            return Ok(response);
        }
    }
}