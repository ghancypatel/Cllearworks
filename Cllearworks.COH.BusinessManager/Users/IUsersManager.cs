using Cllearworks.COH.Models.Users;
using Cllearworks.COH.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cllearworks.COH.BusinessManager.Users
{
    public interface IUsersManager
    {
        Task<IEnumerable<UserModel>> GetUsers();
    }
}
