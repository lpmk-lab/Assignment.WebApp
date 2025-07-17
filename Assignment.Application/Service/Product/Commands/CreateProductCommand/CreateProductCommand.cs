

using Assignment.Application.Service.Product.Common;
using ErrorOr;
using MediatR;

namespace Assignment.Application.Service.Product.Commands.CreateProductCommand
{
    public record CreateProductCommand
    (
        string Name,
        string Description
    ):IRequest<ErrorOr<bool>>;
}
