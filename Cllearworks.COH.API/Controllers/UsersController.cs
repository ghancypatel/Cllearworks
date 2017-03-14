using Cllearworks.COH.BusinessManager.Users;
using Cllearworks.COH.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Cllearworks.COH.API.Controllers
{
    //[Authorize]
    [RoutePrefix("Users")]
    public class UsersController : ApiController
    {
        private readonly IUsersManager _userManager;

        public UsersController()
        {
            _userManager = new UsersManager();
        }

        [HttpGet]
        [Route("")]
        public async Task<IHttpActionResult> Get()
        {
            return Ok(await _userManager.GetUsersAsync());
        }

        [HttpGet]
        [Route("{userId}")]
        public async Task<IHttpActionResult> Get(int id)
        {
            return Ok(await _userManager.GetUserByIdAsync(id));
        }

        [HttpPost]
        [Route("")]
        public async Task<IHttpActionResult> Post(string firstName, string lastName, string email, string password)
        {
            var user = await _userManager.CreateUserAsync(firstName, lastName, email, password);

            return Ok(user);
        }
    }
}
