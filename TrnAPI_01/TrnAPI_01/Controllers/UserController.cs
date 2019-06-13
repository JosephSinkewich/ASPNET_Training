using BLL.Services.Interfaces;
using Common.Model;
using System.Collections.Generic;
using System.Web.Http;
using TrnAPI_01.Models;

namespace TrnAPI_01.Controllers
{
    public class UserController : ApiController
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        // GET api/<controller>
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return userService.GetAll();
        }

        // GET api/<controller>/5
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            User user = userService.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        // POST api/<controller>
        [HttpPost]
        public IHttpActionResult Post([FromBody]CreateUserViewModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }
            User user = new User
            {
                Name = model.Name,
                Password = model.Password,
                RoleId = model.RoleId,
                EmailId = model.EmailId
            };

            userService.Create(user);

            return Ok();
        }

        // PUT api/<controller>/5
        [HttpPut]
        public IHttpActionResult Put(int id, [FromBody]User model)
        {
            if (model == null)
            {
                return BadRequest();
            }
            if (id != model.Id)
            {
                return BadRequest();
            }

            userService.Update(model);
            return Ok();
        }

        // DELETE api/<controller>/5
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            userService.Delete(id);
            return Ok();
        }
    }
}
