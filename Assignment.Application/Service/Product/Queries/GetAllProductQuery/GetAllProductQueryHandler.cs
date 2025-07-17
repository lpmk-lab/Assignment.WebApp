using Assignment.Application.Common.Interface.Persistence;

using Assignment.Domain;
using ErrorOr;
using MediatR;
using Assignment.Domain.Common.Errors;


namespace Assignment.Application.Service.Product.Queries.GetAllProductQuery
{
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQuery, ErrorOr<IEnumerable<ProductDomain>>>
    {
        private readonly IProductRepository _productRepository;

        public GetAllProductQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;

        }

        public async Task<ErrorOr<IEnumerable<ProductDomain>>> Handle(GetAllProductQuery query, CancellationToken cancellationToken)
        {
        
            return await _productRepository.GetAllAsync();

        }
    }
}