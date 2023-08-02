using System.Collections.Generic;
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
    public class List : EndpointBaseAsync.WithRequest<ListAdvisorPhoneNumberRequest>.WithActionResult<
        ListAdvisorPhoneNumberResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<AdvisorPhoneNumber> _repository;

        public List(IRepository<AdvisorPhoneNumber> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/advisorPhoneNumbers")]
        [SwaggerOperation(
            Summary = "List AdvisorPhoneNumbers",
            Description = "List AdvisorPhoneNumbers",
            OperationId = "advisorPhoneNumbers.List",
            Tags = new[] { "AdvisorPhoneNumberEndpoints" })
        ]
        public override async Task<ActionResult<ListAdvisorPhoneNumberResponse>> HandleAsync(
            [FromQuery] ListAdvisorPhoneNumberRequest request,
            CancellationToken cancellationToken)
        {
            var response = new ListAdvisorPhoneNumberResponse(request.CorrelationId());

            var spec = new AdvisorPhoneNumberGetListSpec();
            var advisorPhoneNumbers = await _repository.ListAsync(spec);
            if (advisorPhoneNumbers is null)
            {
                return NotFound();
            }

            response.AdvisorPhoneNumbers = _mapper.Map<List<AdvisorPhoneNumberDto>>(advisorPhoneNumbers);
            response.Count = response.AdvisorPhoneNumbers.Count;

            return Ok(response);
        }
    }
}