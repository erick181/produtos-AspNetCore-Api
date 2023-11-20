using project_products.Models;

namespace project_products.Services.Interface
{
    public interface ITokenService
    {
        public string GetToken(User user);

    }
}
