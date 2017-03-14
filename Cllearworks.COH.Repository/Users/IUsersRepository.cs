using System.Linq;
using System.Threading.Tasks;

namespace Cllearworks.COH.Repository.Users
{
    public interface IUsersRepository
    {
        Task<IQueryable<User>> GetUsersAsync();
        Task<User> GetUserByIdAsync(int id);
        Task<User> GetUserByEmailAsync(string email);
        Task<User> CreateUserAsync(User user);

        IQueryable<User> GetUsers();
        User GetUserByEmail(string email);
    }
}
