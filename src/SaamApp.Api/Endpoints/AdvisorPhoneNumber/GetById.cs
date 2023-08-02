using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.AdvisorPhoneNumber;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.AdvisorPhoneNumberEndpoints
{
    public class GetById : EndpointBaseAsync.WithRequest<GetByIdAdvisorPhoneNumberRequest>.WithActionResult<
        GetByIdAdvisorPhoneNumberResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<AdvisorPhoneNumber> _repository;

        public GetById(
            IRepository<AdvisorPhoneNumber> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/advisorPhoneNumbers/{RowId}")]
        [SwaggerOperation(
            Summary = "Get a AdvisorPhoneNumber by Id",
            Description = "Gets a AdvisorPhoneNumber by Id",
            OperationId = "advisorPhoneNumbers.GetById",
            Tags = new[] { "AdvisorPhoneNumberEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdAdvisorPhoneNumberResponse>> HandleAsync(
            [FromRoute] GetByIdAdvisorPhoneNumberRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdAdvisorPhoneNumberResponse(request.CorrelationId());

            var advisorPhoneNumber = await _repository.GetByIdAsync(request.RowId);
            if (advisorPhoneNumber is null)
            {
                return NotFound();
            }

            response.AdvisorPhoneNumber = _mapper.Map<AdvisorPhoneNumberDto>(advisorPhoneNumber);

            return Ok(response);
        }
    }
}