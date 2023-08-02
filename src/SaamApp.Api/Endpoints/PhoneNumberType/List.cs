using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.PhoneNumberType;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.PhoneNumberTypeEndpoints
{
    public class List : EndpointBaseAsync.WithRequest<ListPhoneNumberTypeRequest>.WithActionResult<
        ListPhoneNumberTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<PhoneNumberType> _repository;

        public List(IRepository<PhoneNumberType> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/phoneNumberTypes")]
        [SwaggerOperation(
            Summary = "List PhoneNumberTypes",
            Description = "List PhoneNumberTypes",
            OperationId = "phoneNumberTypes.List",
            Tags = new[] { "PhoneNumberTypeEndpoints" })
        ]
        public override async Task<ActionResult<ListPhoneNumberTypeResponse>> HandleAsync(
            [FromQuery] ListPhoneNumberTypeRequest request,
            CancellationToken cancellationToken)
        {
            var response = new ListPhoneNumberTypeResponse(request.CorrelationId());

            var spec = new PhoneNumberTypeGetListSpec();
            var phoneNumberTypes = await _repository.ListAsync(spec);
            if (phoneNumberTypes is null)
            {
                return NotFound();
            }

            response.PhoneNumberTypes = _mapper.Map<List<PhoneNumberTypeDto>>(phoneNumberTypes);
            response.Count = response.PhoneNumberTypes.Count;

            return Ok(response);
        }
    }
}