using Assignment.Application.Service.Product.Common;
using ErrorOr;
using MediatR;

namespace Assignment.Application.Service.Product.Queries.GetProductQuery
{
    public record GetProductQuery
      (
        int Id
    ) : IRequest<ErrorOr<ProductResponse>>;
}
