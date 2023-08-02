using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.AdvisorEmailAddress;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.AdvisorEmailAddressEndpoints
{
    public class GetByRelsIds : EndpointBaseAsync.WithRequest<GetByRelsIdsAdvisorEmailAddressRequest>.WithActionResult<
        GetByIdAdvisorEmailAddressResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<AdvisorEmailAddress> _repository;

        public GetByRelsIds(
            IRepository<AdvisorEmailAddress> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/advisorEmailAddresses/{AdvisorId}/{EmailAddressId}")]
        [SwaggerOperation(
            Summary = "Get a AdvisorEmailAddress by rel Ids",
            Description = "Gets a AdvisorEmailAddress by rel Ids",
            OperationId = "advisorEmailAddresses.GetByRelsIds",
            Tags = new[] { "AdvisorEmailAddressEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdAdvisorEmailAddressResponse>> HandleAsync(
            [FromRoute] GetByRelsIdsAdvisorEmailAddressRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdAdvisorEmailAddressResponse(request.CorrelationId());

            var spec = new AdvisorEmailAddressByRelIdsSpec(request.AdvisorId, request.EmailAddressId);

            var advisorEmailAddress = await _repository.FirstOrDefaultAsync(spec);


            if (advisorEmailAddress is null)
            {
                return NotFound();
            }

            response.AdvisorEmailAddress = _mapper.Map<AdvisorEmailAddressDto>(advisorEmailAddress);

            return Ok(response);
        }
    }
}