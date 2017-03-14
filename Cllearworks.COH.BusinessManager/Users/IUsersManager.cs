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
        Task<IEnumerable<UserModel>> GetUsersAsync();
        Task<UserModel> GetUserByIdAsync(int id);
        Task<UserModel> GetUserByEmailAsync(string email);
        Task<UserModel> CreateUserAsync(string firstName, string lastName, string email, string password);

        IEnumerable<UserModel> GetUsers();
        UserModel GetUserByEmail(string email);
    }
}
