using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.CustomerDocument;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.CustomerDocumentEndpoints
{
    public class List : EndpointBaseAsync.WithRequest<ListCustomerDocumentRequest>.WithActionResult<
        ListCustomerDocumentResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<CustomerDocument> _repository;

        public List(IRepository<CustomerDocument> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/customerDocuments")]
        [SwaggerOperation(
            Summary = "List CustomerDocuments",
            Description = "List CustomerDocuments",
            OperationId = "customerDocuments.List",
            Tags = new[] { "CustomerDocumentEndpoints" })
        ]
        public override async Task<ActionResult<ListCustomerDocumentResponse>> HandleAsync(
            [FromQuery] ListCustomerDocumentRequest request,
            CancellationToken cancellationToken)
        {
            var response = new ListCustomerDocumentResponse(request.CorrelationId());

            var spec = new CustomerDocumentGetListSpec();
            var customerDocuments = await _repository.ListAsync(spec);
            if (customerDocuments is null)
            {
                return NotFound();
            }

            response.CustomerDocuments = _mapper.Map<List<CustomerDocumentDto>>(customerDocuments);
            response.Count = response.CustomerDocuments.Count;

            return Ok(response);
        }
    }
}