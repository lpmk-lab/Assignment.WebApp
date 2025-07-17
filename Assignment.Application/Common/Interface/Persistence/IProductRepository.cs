using Assignment.Domain;
namespace Assignment.Application.Common.Interface.Persistence
{
    public interface IProductRepository
    {
        Task<bool> AddAsync(ProductDomain product);
        Task<bool> UpdateAsync(ProductDomain product);
        Task<bool> DeleteAsync(int id);
        Task<ProductDomain> GetByIdAsync(int id);
        Task<ProductDomain> GetByNameAsync(string name);
        Task<List<ProductDomain>> GetAllAsync();
    }
}
