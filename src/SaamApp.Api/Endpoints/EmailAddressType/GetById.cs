using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.EmailAddressType;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.EmailAddressTypeEndpoints
{
    public class GetById : EndpointBaseAsync.WithRequest<GetByIdEmailAddressTypeRequest>.WithActionResult<
        GetByIdEmailAddressTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<EmailAddressType> _repository;

        public GetById(
            IRepository<EmailAddressType> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/emailAddressTypes/{EmailAddressTypeId}")]
        [SwaggerOperation(
            Summary = "Get a EmailAddressType by Id",
            Description = "Gets a EmailAddressType by Id",
            OperationId = "emailAddressTypes.GetById",
            Tags = new[] { "EmailAddressTypeEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdEmailAddressTypeResponse>> HandleAsync(
            [FromRoute] GetByIdEmailAddressTypeRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdEmailAddressTypeResponse(request.CorrelationId());

            var emailAddressType = await _repository.GetByIdAsync(request.EmailAddressTypeId);
            if (emailAddressType is null)
            {
                return NotFound();
            }

            response.EmailAddressType = _mapper.Map<EmailAddressTypeDto>(emailAddressType);

            return Ok(response);
        }
    }
}