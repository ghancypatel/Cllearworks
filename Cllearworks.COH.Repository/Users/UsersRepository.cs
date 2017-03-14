using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cllearworks.COH.Repository.Users
{
    public class UsersRepository : BaseRepository, IUsersRepository
    {
        public async Task<IQueryable<User>> GetUsersAsync()
        {
            return await Task.Run(() => {
                return Context.Users;
            });
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await Task.Run(() => {
                return Context.Users.Where(u => u.Id == id).FirstOrDefault();
            });
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await Task.Run(() => {
                return Context.Users.Where(u => u.Email == email).FirstOrDefault();
            });
        }

        public async Task<User> CreateUserAsync(User user)
        {
            return await Task.Run(() => {

                Context.Users.Add(user);
                Context.SaveChanges();

                return Context.Users.Find(user.Id);
            });
        }

        IQueryable<User> IUsersRepository.GetUsers()
        {
            return Context.Users;
        }

        public User GetUserByEmail(string email)
        {
            return Context.Users.Where(u => u.Email == email).FirstOrDefault();
        }
    }
}
