using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.AdvisorPhoneNumber;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.AdvisorPhoneNumberEndpoints
{
    public class GetByRelsIds : EndpointBaseAsync.WithRequest<GetByRelsIdsAdvisorPhoneNumberRequest>.WithActionResult<
        GetByIdAdvisorPhoneNumberResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<AdvisorPhoneNumber> _repository;

        public GetByRelsIds(
            IRepository<AdvisorPhoneNumber> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/advisorPhoneNumbers/{AdvisorId}/{PhoneNumberId}")]
        [SwaggerOperation(
            Summary = "Get a AdvisorPhoneNumber by rel Ids",
            Description = "Gets a AdvisorPhoneNumber by rel Ids",
            OperationId = "advisorPhoneNumbers.GetByRelsIds",
            Tags = new[] { "AdvisorPhoneNumberEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdAdvisorPhoneNumberResponse>> HandleAsync(
            [FromRoute] GetByRelsIdsAdvisorPhoneNumberRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdAdvisorPhoneNumberResponse(request.CorrelationId());

            var spec = new AdvisorPhoneNumberByRelIdsSpec(request.AdvisorId, request.PhoneNumberId);

            var advisorPhoneNumber = await _repository.FirstOrDefaultAsync(spec);


            if (advisorPhoneNumber is null)
            {
                return NotFound();
            }

            response.AdvisorPhoneNumber = _mapper.Map<AdvisorPhoneNumberDto>(advisorPhoneNumber);

            return Ok(response);
        }
    }
}