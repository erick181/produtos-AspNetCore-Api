using Microsoft.EntityFrameworkCore;
using project_products.Data;
using project_products.Models;
using project_products.Repositories.Interface;

namespace project_products.Repositories
{
    public class UserRepository : IUserRepository
    {

        private ContextDB _contextDB;

        public UserRepository(ContextDB contextDB)
        {
            _contextDB = contextDB;
        }
        public async Task<List<User>> GetAll()
        {
            List<User> users = await _contextDB.Users.ToListAsync();

            return users;
        }

        public async Task<User> GetUser(string username, string password)
        {

            return await _contextDB.Users.Where(x => x.Username.ToLower() == username.ToLower() && x.Password == password)
                .FirstOrDefaultAsync();
  
        }
    }
}
