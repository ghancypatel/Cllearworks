using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cllearworks.COH.Repository.Applications
{
    public class ApplicationRepository : BaseRepository, IApplicationRepository
    {
        public async Task<Application> GetApplication(int id)
        {
            return await Task.Run(() =>
            {
                return Context.Applications.Where(a => a.Id == id).FirstOrDefault();
            });
        }

        public async Task<IQueryable<Application>> GetApplications()
        {
            return await Task.Run(() =>
            {
                return Context.Applications;
            });
        }

        public bool VerifyApplicationSecret(Guid clientId, Guid clientSecret)
        {
            return Context.Applications.Any(a => a.ClientId == clientId && a.ClientSecret == clientSecret);
        }

        public async Task<bool> VerifyApplicationSecretAsync(Guid clientId, Guid clientSecret)
        {
            return await Task.Run(() => {
                return Context.Applications.Any(a => a.ClientId == clientId && a.ClientSecret == clientSecret);
            });
        }
    }
}
