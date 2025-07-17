using ErrorOr;
using MediatR;
using Assignment.Domain.Common.Errors;


namespace Assignment.Application.Service.Product.Commands.DeleteProductCommand
{
    public record DeleteProductCommand
   (
        int Id
    ) : IRequest<ErrorOr<bool>>;
}
