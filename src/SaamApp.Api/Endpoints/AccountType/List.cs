using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.AccountType;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.AccountTypeEndpoints
{
    public class List : EndpointBaseAsync.WithRequest<ListAccountTypeRequest>.WithActionResult<ListAccountTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<AccountType> _repository;

        public List(IRepository<AccountType> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/accountTypes")]
        [SwaggerOperation(
            Summary = "List AccountTypes",
            Description = "List AccountTypes",
            OperationId = "accountTypes.List",
            Tags = new[] { "AccountTypeEndpoints" })
        ]
        public override async Task<ActionResult<ListAccountTypeResponse>> HandleAsync(
            [FromQuery] ListAccountTypeRequest request,
            CancellationToken cancellationToken)
        {
            var response = new ListAccountTypeResponse(request.CorrelationId());

            var spec = new AccountTypeGetListSpec();
            var accountTypes = await _repository.ListAsync(spec);
            if (accountTypes is null)
            {
                return NotFound();
            }

            response.AccountTypes = _mapper.Map<List<AccountTypeDto>>(accountTypes);
            response.Count = response.AccountTypes.Count;

            return Ok(response);
        }
    }
}