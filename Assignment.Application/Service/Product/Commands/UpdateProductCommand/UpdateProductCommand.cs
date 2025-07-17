
using ErrorOr;
using MediatR;

namespace Assignment.Application.Service.Product.Commands.UpdateProductCommand
{
    public record UpdateProductCommand
    (
        int Id,
        string Name,
        string Description
    ):IRequest<ErrorOr<bool>>;
}
