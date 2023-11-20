using Microsoft.EntityFrameworkCore;
using project_products.Data;
using project_products.Models;
using project_products.Repositories.Interface;

namespace project_products.Repositories
{
    public class ProductRepository : IProductRepository
    {

        private readonly ContextDB _contextDB;

        public ProductRepository(ContextDB contextDB)
        {
            _contextDB = contextDB;
        }

        public async Task<List<Product>> GetAll()
        {
            return await _contextDB.Products.ToListAsync();
        }

        public async Task<Product> GetById(int id)
        {
            return await _contextDB.Products.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Product> Add(Product product)
        {
            await _contextDB.Products.AddAsync(product);
            await _contextDB.SaveChangesAsync();

            return product;
        }

        public async Task<bool> Delete(int id)
        {
            Product productReturn = await GetById(id);

            if (productReturn == null)
            {
                throw new Exception($"Produto com id {id} não encontrado");
            }

            _contextDB.Products.Remove(productReturn);
            await _contextDB.SaveChangesAsync();

            return true;
        }

        public async Task<Product> Update(Product product, int id)
        {
            Product productReturn = await GetById(id);

            if (productReturn == null)
            {
                throw new Exception($"Produto com id {id} não encontrado");
            }

            productReturn.Name = product.Name;
            productReturn.Description = product.Description;
            productReturn.Price = product.Price;


            _contextDB.Products.Update(productReturn);
            await _contextDB.SaveChangesAsync();

            return productReturn;

        }
    }
}
