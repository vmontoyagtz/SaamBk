using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.GiftCode;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.GiftCodeEndpoints
{
    public class GetById : EndpointBaseAsync.WithRequest<GetByIdGiftCodeRequest>.WithActionResult<
        GetByIdGiftCodeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<GiftCode> _repository;

        public GetById(
            IRepository<GiftCode> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/giftCodes/{GiftCodeId}")]
        [SwaggerOperation(
            Summary = "Get a GiftCode by Id",
            Description = "Gets a GiftCode by Id",
            OperationId = "giftCodes.GetById",
            Tags = new[] { "GiftCodeEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdGiftCodeResponse>> HandleAsync(
            [FromRoute] GetByIdGiftCodeRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdGiftCodeResponse(request.CorrelationId());

            var giftCode = await _repository.GetByIdAsync(request.GiftCodeId);
            if (giftCode is null)
            {
                return NotFound();
            }

            response.GiftCode = _mapper.Map<GiftCodeDto>(giftCode);

            return Ok(response);
        }
    }
}