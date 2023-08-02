using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.PrepaidPackageRedemption;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.PrepaidPackageRedemptionEndpoints
{
    public class List : EndpointBaseAsync.WithRequest<ListPrepaidPackageRedemptionRequest>.WithActionResult<
        ListPrepaidPackageRedemptionResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<PrepaidPackageRedemption> _repository;

        public List(IRepository<PrepaidPackageRedemption> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/prepaidPackageRedemptions")]
        [SwaggerOperation(
            Summary = "List PrepaidPackageRedemptions",
            Description = "List PrepaidPackageRedemptions",
            OperationId = "prepaidPackageRedemptions.List",
            Tags = new[] { "PrepaidPackageRedemptionEndpoints" })
        ]
        public override async Task<ActionResult<ListPrepaidPackageRedemptionResponse>> HandleAsync(
            [FromQuery] ListPrepaidPackageRedemptionRequest request,
            CancellationToken cancellationToken)
        {
            var response = new ListPrepaidPackageRedemptionResponse(request.CorrelationId());

            var spec = new PrepaidPackageRedemptionGetListSpec();
            var prepaidPackageRedemptions = await _repository.ListAsync(spec);
            if (prepaidPackageRedemptions is null)
            {
                return NotFound();
            }

            response.PrepaidPackageRedemptions =
                _mapper.Map<List<PrepaidPackageRedemptionDto>>(prepaidPackageRedemptions);
            response.Count = response.PrepaidPackageRedemptions.Count;

            return Ok(response);
        }
    }
}