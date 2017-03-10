using System.Linq;
using System.Threading.Tasks;

namespace Cllearworks.COH.Repository.Users
{
    public interface IUsersRepository
    {
        Task<IQueryable<User>> GetUsers();
    }
}
