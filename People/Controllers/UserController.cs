using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using People.Models;
using People.Services;

namespace People.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private IUserDataProvider userDataProvider;

        public UserController(IUserDataProvider userDataProvider)
        {
            this.userDataProvider = userDataProvider;
        }

        [HttpGet]
        public async Task<IEnumerable<User>> Get()
        {
            return await this.userDataProvider.GetUsers();
        }

        [HttpGet("{id}")]
        public async Task<User> Get(int UserId)
        {
            return await this.userDataProvider.GetUser(UserId);
        }

        [HttpPost]
        public async Task Post([FromBody]User user)
        {
            await this.userDataProvider.AddUser(user);
        }

        [HttpPut("{id}")]
        public async Task Put(int UserId, [FromBody]User user)
        {
            await this.userDataProvider.UpdateUser(user);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int UserId)
        {
            await this.userDataProvider.DeleteUser(UserId);
        }

    }
}
    
