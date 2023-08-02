using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.GiftCode;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.GiftCodeEndpoints
{
    public class List : EndpointBaseAsync.WithRequest<ListGiftCodeRequest>.WithActionResult<ListGiftCodeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<GiftCode> _repository;

        public List(IRepository<GiftCode> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/giftCodes")]
        [SwaggerOperation(
            Summary = "List GiftCodes",
            Description = "List GiftCodes",
            OperationId = "giftCodes.List",
            Tags = new[] { "GiftCodeEndpoints" })
        ]
        public override async Task<ActionResult<ListGiftCodeResponse>> HandleAsync(
            [FromQuery] ListGiftCodeRequest request,
            CancellationToken cancellationToken)
        {
            var response = new ListGiftCodeResponse(request.CorrelationId());

            var spec = new GiftCodeGetListSpec();
            var giftCodes = await _repository.ListAsync(spec);
            if (giftCodes is null)
            {
                return NotFound();
            }

            response.GiftCodes = _mapper.Map<List<GiftCodeDto>>(giftCodes);
            response.Count = response.GiftCodes.Count;

            return Ok(response);
        }
    }
}