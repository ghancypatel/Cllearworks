using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cllearworks.COH.Repository.Applications
{
    public interface IApplicationRepository
    {
        Task<IQueryable<Application>> GetApplications();
        Task<Application> GetApplication(int id);
        bool VerifyApplicationSecret(Guid clientId, Guid clientSecret);
        Task<bool> VerifyApplicationSecretAsync(Guid clientId, Guid clientSecret);
    }
}
