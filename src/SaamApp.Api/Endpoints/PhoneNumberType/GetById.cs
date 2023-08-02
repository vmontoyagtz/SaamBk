using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.PhoneNumberType;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.PhoneNumberTypeEndpoints
{
    public class GetById : EndpointBaseAsync.WithRequest<GetByIdPhoneNumberTypeRequest>.WithActionResult<
        GetByIdPhoneNumberTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<PhoneNumberType> _repository;

        public GetById(
            IRepository<PhoneNumberType> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/phoneNumberTypes/{PhoneNumberTypeId}")]
        [SwaggerOperation(
            Summary = "Get a PhoneNumberType by Id",
            Description = "Gets a PhoneNumberType by Id",
            OperationId = "phoneNumberTypes.GetById",
            Tags = new[] { "PhoneNumberTypeEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdPhoneNumberTypeResponse>> HandleAsync(
            [FromRoute] GetByIdPhoneNumberTypeRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdPhoneNumberTypeResponse(request.CorrelationId());

            var phoneNumberType = await _repository.GetByIdAsync(request.PhoneNumberTypeId);
            if (phoneNumberType is null)
            {
                return NotFound();
            }

            response.PhoneNumberType = _mapper.Map<PhoneNumberTypeDto>(phoneNumberType);

            return Ok(response);
        }
    }
}