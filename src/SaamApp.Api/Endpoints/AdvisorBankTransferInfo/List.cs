using System.Collections.Generic;
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
    public class List : EndpointBaseAsync.WithRequest<ListAdvisorBankTransferInfoRequest>.WithActionResult<
        ListAdvisorBankTransferInfoResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<AdvisorBankTransferInfo> _repository;

        public List(IRepository<AdvisorBankTransferInfo> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/advisorBankTransferInfoes")]
        [SwaggerOperation(
            Summary = "List AdvisorBankTransferInfoes",
            Description = "List AdvisorBankTransferInfoes",
            OperationId = "advisorBankTransferInfoes.List",
            Tags = new[] { "AdvisorBankTransferInfoEndpoints" })
        ]
        public override async Task<ActionResult<ListAdvisorBankTransferInfoResponse>> HandleAsync(
            [FromQuery] ListAdvisorBankTransferInfoRequest request,
            CancellationToken cancellationToken)
        {
            var response = new ListAdvisorBankTransferInfoResponse(request.CorrelationId());

            var spec = new AdvisorBankTransferInfoGetListSpec();
            var advisorBankTransferInfoes = await _repository.ListAsync(spec);
            if (advisorBankTransferInfoes is null)
            {
                return NotFound();
            }

            response.AdvisorBankTransferInfoes =
                _mapper.Map<List<AdvisorBankTransferInfoDto>>(advisorBankTransferInfoes);
            response.Count = response.AdvisorBankTransferInfoes.Count;

            return Ok(response);
        }
    }
}