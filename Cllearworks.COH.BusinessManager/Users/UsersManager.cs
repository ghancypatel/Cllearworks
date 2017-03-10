using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cllearworks.COH.Repository;
using Cllearworks.COH.Repository.Users;
using Cllearworks.COH.Models.Users;

namespace Cllearworks.COH.BusinessManager.Users
{
    public class UsersManager : IUsersManager
    {
        private readonly IUsersRepository _usersRepository;
        private readonly UsersMappingFactory _usersMapper;
        public UsersManager()
        {
            _usersRepository = new UsersRepository();
            _usersMapper = new UsersMappingFactory();
        }

        public async Task<IEnumerable<UserModel>> GetUsers()
        {
            var users = await _usersRepository.GetUsers();

            return users.ToList().Select(u => _usersMapper.ConvertToModel(u));
        }
    }
}
