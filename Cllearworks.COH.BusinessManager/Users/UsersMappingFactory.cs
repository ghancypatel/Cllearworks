using Cllearworks.COH.Models.Users;
using Cllearworks.COH.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cllearworks.COH.BusinessManager.Users
{
    public class UsersMappingFactory
    {
        public User ConvertToDataModel(UserModel model)
        {
            if (model == null)
                return null;

            var dataModel = new User();
            dataModel.Id = model.Id;
            dataModel.FirstName = model.FirstName;
            dataModel.LastName = model.LastName;
            dataModel.Email = model.Email;

            return dataModel;
        }

        public UserModel ConvertToModel(User dataModel)
        {
            if (dataModel == null)
                return null;

            var model = new UserModel();
            model.Id = dataModel.Id;
            model.FirstName = dataModel.FirstName;
            model.LastName = dataModel.LastName;
            model.Email = dataModel.Email;

            return model;
        }
    }
}
