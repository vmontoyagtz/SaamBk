using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.AccountType;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.AccountTypeEndpoints
{
    public class GetById : EndpointBaseAsync.WithRequest<GetByIdAccountTypeRequest>.WithActionResult<
        GetByIdAccountTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<AccountType> _repository;

        public GetById(
            IRepository<AccountType> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/accountTypes/{AccountTypeId}")]
        [SwaggerOperation(
            Summary = "Get a AccountType by Id",
            Description = "Gets a AccountType by Id",
            OperationId = "accountTypes.GetById",
            Tags = new[] { "AccountTypeEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdAccountTypeResponse>> HandleAsync(
            [FromRoute] GetByIdAccountTypeRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdAccountTypeResponse(request.CorrelationId());

            var accountType = await _repository.GetByIdAsync(request.AccountTypeId);
            if (accountType is null)
            {
                return NotFound();
            }

            response.AccountType = _mapper.Map<AccountTypeDto>(accountType);

            return Ok(response);
        }
    }
}