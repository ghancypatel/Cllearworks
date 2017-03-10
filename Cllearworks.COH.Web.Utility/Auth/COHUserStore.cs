using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cllearworks.COH.Web.Utility.Auth
{
    public class COHUserStore : IUserPasswordStore<COHApplicationUser, string>
    {
        private bool _disposed;
        public bool DisposeContext { get; set; }

        public COHUserStore()
        {
            DisposeContext = true;
        }

        public Task CreateAsync(COHApplicationUser user)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(COHApplicationUser user)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public Task<COHApplicationUser> FindByIdAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<COHApplicationUser> FindByNameAsync(string userName)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetPasswordHashAsync(COHApplicationUser user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> HasPasswordAsync(COHApplicationUser user)
        {
            throw new NotImplementedException();
        }

        public Task SetPasswordHashAsync(COHApplicationUser user, string passwordHash)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(COHApplicationUser user)
        {
            throw new NotImplementedException();
        }

        protected virtual void Dispose(bool disposing)
        {
            _disposed = true;
        }
    }
}
