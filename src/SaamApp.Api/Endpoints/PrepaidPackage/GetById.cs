using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.PrepaidPackage;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.PrepaidPackageEndpoints
{
    public class GetById : EndpointBaseAsync.WithRequest<GetByIdPrepaidPackageRequest>.WithActionResult<
        GetByIdPrepaidPackageResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<PrepaidPackage> _repository;

        public GetById(
            IRepository<PrepaidPackage> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/prepaidPackages/{PrepaidPackageId}")]
        [SwaggerOperation(
            Summary = "Get a PrepaidPackage by Id",
            Description = "Gets a PrepaidPackage by Id",
            OperationId = "prepaidPackages.GetById",
            Tags = new[] { "PrepaidPackageEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdPrepaidPackageResponse>> HandleAsync(
            [FromRoute] GetByIdPrepaidPackageRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdPrepaidPackageResponse(request.CorrelationId());

            var prepaidPackage = await _repository.GetByIdAsync(request.PrepaidPackageId);
            if (prepaidPackage is null)
            {
                return NotFound();
            }

            response.PrepaidPackage = _mapper.Map<PrepaidPackageDto>(prepaidPackage);

            return Ok(response);
        }
    }
}