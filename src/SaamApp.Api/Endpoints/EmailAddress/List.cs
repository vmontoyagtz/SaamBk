using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.EmailAddress;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.EmailAddressEndpoints
{
    public class List : EndpointBaseAsync.WithRequest<ListEmailAddressRequest>.WithActionResult<
        ListEmailAddressResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<EmailAddress> _repository;

        public List(IRepository<EmailAddress> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/emailAddresses")]
        [SwaggerOperation(
            Summary = "List EmailAddresses",
            Description = "List EmailAddresses",
            OperationId = "emailAddresses.List",
            Tags = new[] { "EmailAddressEndpoints" })
        ]
        public override async Task<ActionResult<ListEmailAddressResponse>> HandleAsync(
            [FromQuery] ListEmailAddressRequest request,
            CancellationToken cancellationToken)
        {
            var response = new ListEmailAddressResponse(request.CorrelationId());

            var spec = new EmailAddressGetListSpec();
            var emailAddresses = await _repository.ListAsync(spec);
            if (emailAddresses is null)
            {
                return NotFound();
            }

            response.EmailAddresses = _mapper.Map<List<EmailAddressDto>>(emailAddresses);
            response.Count = response.EmailAddresses.Count;

            return Ok(response);
        }
    }
}