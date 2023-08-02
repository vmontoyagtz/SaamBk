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
    public class GetByIdWithIncludes : EndpointBaseAsync.WithRequest<GetByIdPrepaidPackageRequest>.WithActionResult<
        GetByIdPrepaidPackageResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<PrepaidPackage> _repository;

        public GetByIdWithIncludes(
            IRepository<PrepaidPackage> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/prepaidPackages/i/{PrepaidPackageId}")]
        [SwaggerOperation(
            Summary = "Get a PrepaidPackage by Id With Includes",
            Description = "Gets a PrepaidPackage by Id With Includes",
            OperationId = "prepaidPackages.GetByIdWithIncludes",
            Tags = new[] { "PrepaidPackageEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdPrepaidPackageResponse>> HandleAsync(
            [FromRoute] GetByIdPrepaidPackageRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdPrepaidPackageResponse(request.CorrelationId());

            var spec = new PrepaidPackageByIdWithIncludesSpec(request.PrepaidPackageId);

            var prepaidPackage = await _repository.FirstOrDefaultAsync(spec);


            if (prepaidPackage is null)
            {
                return NotFound();
            }

            response.PrepaidPackage = _mapper.Map<PrepaidPackageDto>(prepaidPackage);

            return Ok(response);
        }
    }
}