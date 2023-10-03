using Ecommerce_server.DTOs;

namespace Ecommerce_server.Services.UserService
{
    public interface IUserService
    {
        Task<List<User>> GetAll();
        Task<User?> GetUserById(int id);
        Task<User> CreateUser(UserDto newUser);
        Task<string?> Login(UserDto newUser);
        Task<List<User>?> DeleteUser(int id);
    }
}
