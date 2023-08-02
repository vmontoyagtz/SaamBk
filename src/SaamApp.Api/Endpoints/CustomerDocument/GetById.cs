using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.CustomerDocument;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.CustomerDocumentEndpoints
{
    public class GetById : EndpointBaseAsync.WithRequest<GetByIdCustomerDocumentRequest>.WithActionResult<
        GetByIdCustomerDocumentResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<CustomerDocument> _repository;

        public GetById(
            IRepository<CustomerDocument> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/customerDocuments/{RowId}")]
        [SwaggerOperation(
            Summary = "Get a CustomerDocument by Id",
            Description = "Gets a CustomerDocument by Id",
            OperationId = "customerDocuments.GetById",
            Tags = new[] { "CustomerDocumentEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdCustomerDocumentResponse>> HandleAsync(
            [FromRoute] GetByIdCustomerDocumentRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdCustomerDocumentResponse(request.CorrelationId());

            var customerDocument = await _repository.GetByIdAsync(request.RowId);
            if (customerDocument is null)
            {
                return NotFound();
            }

            response.CustomerDocument = _mapper.Map<CustomerDocumentDto>(customerDocument);

            return Ok(response);
        }
    }
}