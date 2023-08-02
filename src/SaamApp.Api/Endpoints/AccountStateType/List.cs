using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.AccountStateType;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.AccountStateTypeEndpoints
{
    public class List : EndpointBaseAsync.WithRequest<ListAccountStateTypeRequest>.WithActionResult<
        ListAccountStateTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<AccountStateType> _repository;

        public List(IRepository<AccountStateType> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/accountStateTypes")]
        [SwaggerOperation(
            Summary = "List AccountStateTypes",
            Description = "List AccountStateTypes",
            OperationId = "accountStateTypes.List",
            Tags = new[] { "AccountStateTypeEndpoints" })
        ]
        public override async Task<ActionResult<ListAccountStateTypeResponse>> HandleAsync(
            [FromQuery] ListAccountStateTypeRequest request,
            CancellationToken cancellationToken)
        {
            var response = new ListAccountStateTypeResponse(request.CorrelationId());

            var spec = new AccountStateTypeGetListSpec();
            var accountStateTypes = await _repository.ListAsync(spec);
            if (accountStateTypes is null)
            {
                return NotFound();
            }

            response.AccountStateTypes = _mapper.Map<List<AccountStateTypeDto>>(accountStateTypes);
            response.Count = response.AccountStateTypes.Count;

            return Ok(response);
        }
    }
}