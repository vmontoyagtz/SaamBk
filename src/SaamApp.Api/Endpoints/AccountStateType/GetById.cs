using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.AccountStateType;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.AccountStateTypeEndpoints
{
    public class GetById : EndpointBaseAsync.WithRequest<GetByIdAccountStateTypeRequest>.WithActionResult<
        GetByIdAccountStateTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<AccountStateType> _repository;

        public GetById(
            IRepository<AccountStateType> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/accountStateTypes/{AccountStateTypeId}")]
        [SwaggerOperation(
            Summary = "Get a AccountStateType by Id",
            Description = "Gets a AccountStateType by Id",
            OperationId = "accountStateTypes.GetById",
            Tags = new[] { "AccountStateTypeEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdAccountStateTypeResponse>> HandleAsync(
            [FromRoute] GetByIdAccountStateTypeRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdAccountStateTypeResponse(request.CorrelationId());

            var accountStateType = await _repository.GetByIdAsync(request.AccountStateTypeId);
            if (accountStateType is null)
            {
                return NotFound();
            }

            response.AccountStateType = _mapper.Map<AccountStateTypeDto>(accountStateType);

            return Ok(response);
        }
    }
}