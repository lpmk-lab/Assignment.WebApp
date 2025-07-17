using Assignment.Application.Common.Interface.Persistence;
using Assignment.Application.Service.Product.Common;
using Assignment.Domain;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Assignment.Application.Service.Product.Queries.GetProductQuery
{
    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, ErrorOr<ProductResponse>>
    {
        private readonly IProductRepository _productRepository;

        public GetProductQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
     
        }

        public async Task<ErrorOr<ProductResponse>> Handle(GetProductQuery query, CancellationToken cancellationToken)
        {

            ProductDomain token =await _productRepository.GetByIdAsync(query.Id);

            return new ProductResponse(token);
        }
    }
}