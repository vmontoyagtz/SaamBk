using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.PrepaidPackage;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.PrepaidPackageEndpoints
{
    public class List : EndpointBaseAsync.WithRequest<ListPrepaidPackageRequest>.WithActionResult<
        ListPrepaidPackageResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<PrepaidPackage> _repository;

        public List(IRepository<PrepaidPackage> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/prepaidPackages")]
        [SwaggerOperation(
            Summary = "List PrepaidPackages",
            Description = "List PrepaidPackages",
            OperationId = "prepaidPackages.List",
            Tags = new[] { "PrepaidPackageEndpoints" })
        ]
        public override async Task<ActionResult<ListPrepaidPackageResponse>> HandleAsync(
            [FromQuery] ListPrepaidPackageRequest request,
            CancellationToken cancellationToken)
        {
            var response = new ListPrepaidPackageResponse(request.CorrelationId());

            var spec = new PrepaidPackageGetListSpec();
            var prepaidPackages = await _repository.ListAsync(spec);
            if (prepaidPackages is null)
            {
                return NotFound();
            }

            response.PrepaidPackages = _mapper.Map<List<PrepaidPackageDto>>(prepaidPackages);
            response.Count = response.PrepaidPackages.Count;

            return Ok(response);
        }
    }
}