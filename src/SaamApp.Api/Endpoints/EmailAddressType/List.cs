using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.EmailAddressType;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.EmailAddressTypeEndpoints
{
    public class List : EndpointBaseAsync.WithRequest<ListEmailAddressTypeRequest>.WithActionResult<
        ListEmailAddressTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<EmailAddressType> _repository;

        public List(IRepository<EmailAddressType> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/emailAddressTypes")]
        [SwaggerOperation(
            Summary = "List EmailAddressTypes",
            Description = "List EmailAddressTypes",
            OperationId = "emailAddressTypes.List",
            Tags = new[] { "EmailAddressTypeEndpoints" })
        ]
        public override async Task<ActionResult<ListEmailAddressTypeResponse>> HandleAsync(
            [FromQuery] ListEmailAddressTypeRequest request,
            CancellationToken cancellationToken)
        {
            var response = new ListEmailAddressTypeResponse(request.CorrelationId());

            var spec = new EmailAddressTypeGetListSpec();
            var emailAddressTypes = await _repository.ListAsync(spec);
            if (emailAddressTypes is null)
            {
                return NotFound();
            }

            response.EmailAddressTypes = _mapper.Map<List<EmailAddressTypeDto>>(emailAddressTypes);
            response.Count = response.EmailAddressTypes.Count;

            return Ok(response);
        }
    }
}