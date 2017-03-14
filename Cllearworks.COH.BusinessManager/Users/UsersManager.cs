using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cllearworks.COH.Repository;
using Cllearworks.COH.Repository.Users;
using Cllearworks.COH.Models.Users;
using Cllearworks.COH.Utility;

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

        public async Task<IEnumerable<UserModel>> GetUsersAsync()
        {
            var users = await _usersRepository.GetUsersAsync();

            return users.ToList().Select(u => _usersMapper.ConvertToModel(u));
        }

        public async Task<UserModel> GetUserByIdAsync(int id)
        {
            var user = await _usersRepository.GetUserByIdAsync(id);
            return _usersMapper.ConvertToModel(user);
        }

        public async Task<UserModel> GetUserByEmailAsync(string email)
        {
            var user = await _usersRepository.GetUserByEmailAsync(email);

            return _usersMapper.ConvertToModel(user);
        }

        public async Task<UserModel> CreateUserAsync(string firstName, string lastName, string email, string password)
        {
            var existing = _usersRepository.GetUserByEmail(email);

            if (existing != null)
            {
                throw new Exception("Email already exists");
                //errors = "Email already exists";
                //return new EnumerableQuery<MonsciergeDataModel.User>(new MonsciergeDataModel.User[0]);
            }

            if (!PasswordHelpers.IsValidPassword(password, new PasswordRequirements()))
            {
                throw new Exception("Password doesn't meet requirements");
                //errors = "Password doesn't meet requirements";
                //return new EnumerableQuery<MonsciergeDataModel.User>(new MonsciergeDataModel.User[0]);
            }

            var user = new User()
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                IsActive = true,
                CreatedOn = DateTime.Now,
                UpdatedOn = DateTime.Now
            };

            string salt;
            string passwordHash;
            PasswordHelpers.GenerateSaltAndHash(password, out salt, out passwordHash);

            user.Salt = salt;
            user.PasswordHash = passwordHash;

            user = await _usersRepository.CreateUserAsync(user);

            return _usersMapper.ConvertToModel(user);
        }

        public IEnumerable<UserModel> GetUsers()
        {
            var users = _usersRepository.GetUsers();

            return users.ToList().Select(u => _usersMapper.ConvertToModel(u));
        }

        public UserModel GetUserByEmail(string email)
        {
            var user = _usersRepository.GetUserByEmail(email);

            return _usersMapper.ConvertToModel(user);
        }
    }
}
