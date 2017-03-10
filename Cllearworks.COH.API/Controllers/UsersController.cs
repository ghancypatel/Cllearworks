using Cllearworks.COH.BusinessManager.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Cllearworks.COH.API.Controllers
{
    [Authorize]
    public class UsersController : ApiController
    {
        private readonly IUsersManager _userManager;

        public UsersController()
        {
            _userManager = new UsersManager();
        }

        public async Task<IHttpActionResult> Get()
        {
            return Ok(await _userManager.GetUsers());
        }
    }
}
