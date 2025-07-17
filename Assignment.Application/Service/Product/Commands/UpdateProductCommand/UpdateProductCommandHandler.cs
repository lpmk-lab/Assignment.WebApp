using Assignment.Application.Common.Interface.Persistence;
using ErrorOr;
using MediatR;
using Assignment.Domain.Common.Errors;

namespace Assignment.Application.Service.Product.Commands.UpdateProductCommand
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, ErrorOr<bool>>
    {

        private readonly IProductRepository _productRepository;

        public UpdateProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<ErrorOr<bool>> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
        {
       

            var product = await _productRepository.GetByIdAsync(command.Id);

            if (product != null)
            {
                product.UpdateDetails(command.Name, command.Description);
                var isUpdated = await _productRepository.UpdateAsync(product);
                if (!isUpdated) return Errors.Product.DBError;

                return true;
            }
            else
            {
                return Errors.Product.NotFound;
            }
        }
    }
}

