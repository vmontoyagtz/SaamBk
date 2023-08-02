using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.AdvisorBankTransferInfo;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.AdvisorBankTransferInfoEndpoints
{
    public class GetById : EndpointBaseAsync.WithRequest<GetByIdAdvisorBankTransferInfoRequest>.WithActionResult<
        GetByIdAdvisorBankTransferInfoResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<AdvisorBankTransferInfo> _repository;

        public GetById(
            IRepository<AdvisorBankTransferInfo> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/advisorBankTransferInfoes/{AdvisorBankTransferInfoId}")]
        [SwaggerOperation(
            Summary = "Get a AdvisorBankTransferInfo by Id",
            Description = "Gets a AdvisorBankTransferInfo by Id",
            OperationId = "advisorBankTransferInfoes.GetById",
            Tags = new[] { "AdvisorBankTransferInfoEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdAdvisorBankTransferInfoResponse>> HandleAsync(
            [FromRoute] GetByIdAdvisorBankTransferInfoRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdAdvisorBankTransferInfoResponse(request.CorrelationId());

            var advisorBankTransferInfo = await _repository.GetByIdAsync(request.AdvisorBankTransferInfoId);
            if (advisorBankTransferInfo is null)
            {
                return NotFound();
            }

            response.AdvisorBankTransferInfo = _mapper.Map<AdvisorBankTransferInfoDto>(advisorBankTransferInfo);

            return Ok(response);
        }
    }
}