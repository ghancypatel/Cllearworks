using Cllearworks.COH.Models.Applications;
using Cllearworks.COH.Repository.Applications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cllearworks.COH.BusinessManager.Applications
{
    public class ApplicationManager : IApplicationManager
    {
        private readonly IApplicationRepository _applicationRepository;
        private readonly ApplicationMappingFactory _applicationMapper;
        public ApplicationManager()
        {
            _applicationRepository = new ApplicationRepository();
            _applicationMapper = new ApplicationMappingFactory();
        }

        public async Task<IEnumerable<ApplicationModel>> GetApplications()
        {
            var apps = await _applicationRepository.GetApplications();
            return apps.ToList().Select(a => _applicationMapper.ConvertToModel(a));
        }

        public async Task<ApplicationModel> GetApplication(int id)
        {
            var app = await _applicationRepository.GetApplication(id);
            return _applicationMapper.ConvertToModel(app);
        }

        public bool VerifyApplicationSecret(Guid clientId, Guid clientSecret)
        {
            return _applicationRepository.VerifyApplicationSecret(clientId, clientSecret);
        }

        public async Task<bool> VerifyApplicationSecretAsync(Guid clientId, Guid clientSecret)
        {
            return await _applicationRepository.VerifyApplicationSecretAsync(clientId, clientSecret);
        }
    }
}
