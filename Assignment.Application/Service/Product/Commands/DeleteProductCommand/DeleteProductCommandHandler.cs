using Assignment.Application.Common.Interface.Persistence;
using Assignment.Domain.Common.Errors;
using ErrorOr;
using MediatR;

namespace Assignment.Application.Service.Product.Commands.DeleteProductCommand
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, ErrorOr<bool>>
    {

        private readonly IProductRepository _productRepository;

        public DeleteProductCommandHandler(IProductRepository productRepository)
        {

            _productRepository = productRepository;
        }
        public async Task<ErrorOr<bool>> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
        {
            if (_productRepository.GetByIdAsync(command.Id) is null)
            {
                return Errors.Product.NotFound;
            }

         
            var isDelete = await _productRepository.DeleteAsync(command.Id);

            if (!isDelete) return Errors.Product.DBError;

            return true;
        }
    }
}