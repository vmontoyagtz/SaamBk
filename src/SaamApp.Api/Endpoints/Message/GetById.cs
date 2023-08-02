using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.Message;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.MessageEndpoints
{
    public class GetById : EndpointBaseAsync.WithRequest<GetByIdMessageRequest>.WithActionResult<
        GetByIdMessageResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Message> _repository;

        public GetById(
            IRepository<Message> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/messages/{MessageId}")]
        [SwaggerOperation(
            Summary = "Get a Message by Id",
            Description = "Gets a Message by Id",
            OperationId = "messages.GetById",
            Tags = new[] { "MessageEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdMessageResponse>> HandleAsync(
            [FromRoute] GetByIdMessageRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdMessageResponse(request.CorrelationId());

            var message = await _repository.GetByIdAsync(request.MessageId);
            if (message is null)
            {
                return NotFound();
            }

            response.Message = _mapper.Map<MessageDto>(message);

            return Ok(response);
        }
    }
}