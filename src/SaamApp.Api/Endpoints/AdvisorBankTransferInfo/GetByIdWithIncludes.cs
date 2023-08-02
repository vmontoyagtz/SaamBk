using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.AdvisorBankTransferInfo;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.AdvisorBankTransferInfoEndpoints
{
    public class GetByIdWithIncludes : EndpointBaseAsync.WithRequest<GetByIdAdvisorBankTransferInfoRequest>.
        WithActionResult<
            GetByIdAdvisorBankTransferInfoResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<AdvisorBankTransferInfo> _repository;

        public GetByIdWithIncludes(
            IRepository<AdvisorBankTransferInfo> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/advisorBankTransferInfoes/i/{AdvisorBankTransferInfoId}")]
        [SwaggerOperation(
            Summary = "Get a AdvisorBankTransferInfo by Id With Includes",
            Description = "Gets a AdvisorBankTransferInfo by Id With Includes",
            OperationId = "advisorBankTransferInfoes.GetByIdWithIncludes",
            Tags = new[] { "AdvisorBankTransferInfoEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdAdvisorBankTransferInfoResponse>> HandleAsync(
            [FromRoute] GetByIdAdvisorBankTransferInfoRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdAdvisorBankTransferInfoResponse(request.CorrelationId());

            var spec = new AdvisorBankTransferInfoByIdWithIncludesSpec(request.AdvisorBankTransferInfoId);

            var advisorBankTransferInfo = await _repository.FirstOrDefaultAsync(spec);


            if (advisorBankTransferInfo is null)
            {
                return NotFound();
            }

            response.AdvisorBankTransferInfo = _mapper.Map<AdvisorBankTransferInfoDto>(advisorBankTransferInfo);

            return Ok(response);
        }
    }
}