using Assignment.Application.Common.Interface.Persistence;
using Assignment.Application.Common.Interface.Services;
using Assignment.Domain;
using Assignment.Domain.Common.Errors;
using ErrorOr;
using MediatR;


namespace Assignment.Application.Service.Product.Commands.CreateProductCommand;

    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ErrorOr<bool>>
    {
   
    private readonly IProductRepository _productRepository;
    private readonly IDateTimeProvider _dateTimeProvider;

        public CreateProductCommandHandler(IProductRepository productRepository, IDateTimeProvider dateTimeProvider)
        {

            _productRepository = productRepository;
            _dateTimeProvider = dateTimeProvider;
        }
        public async Task<ErrorOr<bool>> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {

            if (_productRepository.GetByNameAsync(command.Name).Result is not null)
            {
                return Errors.Product.DuplicateName;
            }

        var product = ProductDomain.Create(
         name: command.Name,
         description: command.Description,
         createdDate: _dateTimeProvider.UtcNow
          );

        var isAdded = await _productRepository.AddAsync(product);

          if(!isAdded) return Errors.Product.DBError;

            return  true;
        }
}
