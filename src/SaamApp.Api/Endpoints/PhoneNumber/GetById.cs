using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.PhoneNumber;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.PhoneNumberEndpoints
{
    public class GetById : EndpointBaseAsync.WithRequest<GetByIdPhoneNumberRequest>.WithActionResult<
        GetByIdPhoneNumberResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<PhoneNumber> _repository;

        public GetById(
            IRepository<PhoneNumber> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/phoneNumbers/{PhoneNumberId}")]
        [SwaggerOperation(
            Summary = "Get a PhoneNumber by Id",
            Description = "Gets a PhoneNumber by Id",
            OperationId = "phoneNumbers.GetById",
            Tags = new[] { "PhoneNumberEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdPhoneNumberResponse>> HandleAsync(
            [FromRoute] GetByIdPhoneNumberRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdPhoneNumberResponse(request.CorrelationId());

            var phoneNumber = await _repository.GetByIdAsync(request.PhoneNumberId);
            if (phoneNumber is null)
            {
                return NotFound();
            }

            response.PhoneNumber = _mapper.Map<PhoneNumberDto>(phoneNumber);

            return Ok(response);
        }
    }
}