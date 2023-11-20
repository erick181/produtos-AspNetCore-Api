using project_products.Models;

namespace project_products.Repositories.Interface
{
    public interface IUserRepository
    {

        public Task<List<User>> GetAll();

        public Task<User> GetUser(string username, string password);


    }
}
