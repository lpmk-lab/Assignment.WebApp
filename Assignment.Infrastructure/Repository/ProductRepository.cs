using Assignment.Application.Common.Interface.Persistence;
using Assignment.Domain;


namespace Assignment.Infrastructure.Repository
{
    public class ProductRepository : IProductRepository
    {

        private readonly ISqlDataAccess _dataAccess;

        public ProductRepository(ISqlDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public async Task<bool> AddAsync(ProductDomain product)
        {
            try
            {
                await _dataAccess.SaveData("sp_create_product", new
                {
                    product.Name,product.Description,product.CreatedDate
                });
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<bool> UpdateAsync(ProductDomain product)
        {
            try
            {
                await _dataAccess.SaveData("sp_update_product", product);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                await _dataAccess.SaveData("sp_delete_product", new {Id=id});
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<ProductDomain> GetByIdAsync(int id)
        {
           IEnumerable<ProductDomain> result=await _dataAccess.GetData<ProductDomain, dynamic>("sp_get_product", new {Id=id});
            return result.FirstOrDefault();
        }

        public async Task<ProductDomain> GetByNameAsync(string name)
        {
            IEnumerable<ProductDomain> result = await _dataAccess.GetData<ProductDomain, dynamic>("sp_get_product", new { Name = name });
            return result.FirstOrDefault();
        }
        public async Task<List<ProductDomain>> GetAllAsync()
        {
            string query = "sp_get_product";
            var data = await _dataAccess.GetData<ProductDomain, dynamic>(query, new { });

            return data.ToList();
        }
    }
}
