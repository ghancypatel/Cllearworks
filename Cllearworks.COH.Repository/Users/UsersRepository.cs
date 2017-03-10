using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cllearworks.COH.Repository.Users
{
    public class UsersRepository : BaseRepository, IUsersRepository
    {
        public async Task<IQueryable<User>> GetUsers()
        {
            return await Task.Run(() => {
                return Context.Users;
            });
        }
    }
}
