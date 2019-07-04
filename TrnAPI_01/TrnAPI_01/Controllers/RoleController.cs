using BLL.Services.Interfaces;
using Common.Model;
using System.Collections.Generic;
using System.Web.Http;
using TrnAPI_01.Models;

namespace TrnAPI_01.Controllers
{
    public class RoleController : ApiController
    {
        private readonly IRoleService roleService;

        public RoleController(IRoleService roleService)
        {
            this.roleService = roleService;
        }

        // GET api/<controller>
        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok(roleService.GetAll());
        }

        // GET api/<controller>/5
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            Role role = roleService.GetById(id);
            if (role == null)
            {
                return NotFound();
            }
            return Ok(role);
        }

        // POST api/<controller>
        [HttpPost]
        public IHttpActionResult Post([FromBody]CreateRoleViewModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }
            Role role = new Role
            {
                Name = model.Name
            };

            roleService.Create(role);

            return Ok();
        }

        // PUT api/<controller>/5
        [HttpPut]
        public IHttpActionResult Put(int id, [FromBody]Role model)
        {
            if (model == null)
            {
                return BadRequest();
            }
            if (id != model.Id)
            {
                return BadRequest();
            }

            roleService.Update(model);
            return Ok();
        }

        // DELETE api/<controller>/5
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            roleService.Delete(id);
            return Ok();
        }
    }
}
