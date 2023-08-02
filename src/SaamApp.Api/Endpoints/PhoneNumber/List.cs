using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.PhoneNumber;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.PhoneNumberEndpoints
{
    public class List : EndpointBaseAsync.WithRequest<ListPhoneNumberRequest>.WithActionResult<ListPhoneNumberResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<PhoneNumber> _repository;

        public List(IRepository<PhoneNumber> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/phoneNumbers")]
        [SwaggerOperation(
            Summary = "List PhoneNumbers",
            Description = "List PhoneNumbers",
            OperationId = "phoneNumbers.List",
            Tags = new[] { "PhoneNumberEndpoints" })
        ]
        public override async Task<ActionResult<ListPhoneNumberResponse>> HandleAsync(
            [FromQuery] ListPhoneNumberRequest request,
            CancellationToken cancellationToken)
        {
            var response = new ListPhoneNumberResponse(request.CorrelationId());

            var spec = new PhoneNumberGetListSpec();
            var phoneNumbers = await _repository.ListAsync(spec);
            if (phoneNumbers is null)
            {
                return NotFound();
            }

            response.PhoneNumbers = _mapper.Map<List<PhoneNumberDto>>(phoneNumbers);
            response.Count = response.PhoneNumbers.Count;

            return Ok(response);
        }
    }
}