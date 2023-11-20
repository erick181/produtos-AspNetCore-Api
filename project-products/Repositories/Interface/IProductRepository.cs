using project_products.Models;

namespace project_products.Repositories.Interface
{
    public interface IProductRepository
    {
        public Task<List<Product>> GetAll();

        public Task<Product> GetById(int id);

        public Task<Product> Add(Product product);

        public Task<Product> Update(Product product, int id);

        public Task<bool> Delete(int id);


    }
}
