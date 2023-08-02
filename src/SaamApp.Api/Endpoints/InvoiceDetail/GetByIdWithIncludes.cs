using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.InvoiceDetail;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.InvoiceDetailEndpoints
{
    public class GetByIdWithIncludes : EndpointBaseAsync.WithRequest<GetByIdInvoiceDetailRequest>.WithActionResult<
        GetByIdInvoiceDetailResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<InvoiceDetail> _repository;

        public GetByIdWithIncludes(
            IRepository<InvoiceDetail> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/invoiceDetails/i/{InvoiceDetailId}")]
        [SwaggerOperation(
            Summary = "Get a InvoiceDetail by Id With Includes",
            Description = "Gets a InvoiceDetail by Id With Includes",
            OperationId = "invoiceDetails.GetByIdWithIncludes",
            Tags = new[] { "InvoiceDetailEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdInvoiceDetailResponse>> HandleAsync(
            [FromRoute] GetByIdInvoiceDetailRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdInvoiceDetailResponse(request.CorrelationId());

            var spec = new InvoiceDetailByIdWithIncludesSpec(request.InvoiceDetailId);

            var invoiceDetail = await _repository.FirstOrDefaultAsync(spec);


            if (invoiceDetail is null)
            {
                return NotFound();
            }

            response.InvoiceDetail = _mapper.Map<InvoiceDetailDto>(invoiceDetail);

            return Ok(response);
        }
    }
}