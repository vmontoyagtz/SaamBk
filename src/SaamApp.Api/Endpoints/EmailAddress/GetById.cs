using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.EmailAddress;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.EmailAddressEndpoints
{
    public class GetById : EndpointBaseAsync.WithRequest<GetByIdEmailAddressRequest>.WithActionResult<
        GetByIdEmailAddressResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<EmailAddress> _repository;

        public GetById(
            IRepository<EmailAddress> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/emailAddresses/{EmailAddressId}")]
        [SwaggerOperation(
            Summary = "Get a EmailAddress by Id",
            Description = "Gets a EmailAddress by Id",
            OperationId = "emailAddresses.GetById",
            Tags = new[] { "EmailAddressEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdEmailAddressResponse>> HandleAsync(
            [FromRoute] GetByIdEmailAddressRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdEmailAddressResponse(request.CorrelationId());

            var emailAddress = await _repository.GetByIdAsync(request.EmailAddressId);
            if (emailAddress is null)
            {
                return NotFound();
            }

            response.EmailAddress = _mapper.Map<EmailAddressDto>(emailAddress);

            return Ok(response);
        }
    }
}