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
    public class GetByIdWithIncludes : EndpointBaseAsync.WithRequest<GetByIdGiftCodeRequest>.WithActionResult<
        GetByIdGiftCodeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<GiftCode> _repository;

        public GetByIdWithIncludes(
            IRepository<GiftCode> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/giftCodes/i/{GiftCodeId}")]
        [SwaggerOperation(
            Summary = "Get a GiftCode by Id With Includes",
            Description = "Gets a GiftCode by Id With Includes",
            OperationId = "giftCodes.GetByIdWithIncludes",
            Tags = new[] { "GiftCodeEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdGiftCodeResponse>> HandleAsync(
            [FromRoute] GetByIdGiftCodeRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdGiftCodeResponse(request.CorrelationId());

            var spec = new GiftCodeByIdWithIncludesSpec(request.GiftCodeId);

            var giftCode = await _repository.FirstOrDefaultAsync(spec);


            if (giftCode is null)
            {
                return NotFound();
            }

            response.GiftCode = _mapper.Map<GiftCodeDto>(giftCode);

            return Ok(response);
        }
    }
}