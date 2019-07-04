using BLL.Services.Interfaces;
using Common.Model;
using System.Collections.Generic;
using System.Web.Http;
using TrnAPI_01.Models;

namespace TrnAPI_01.Controllers
{
    public class EmailController : ApiController
    {
        private readonly IEmailService emailService;

        public EmailController(IEmailService emailService)
        {
            this.emailService = emailService;
        }

        // GET api/<controller>
        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok(emailService.GetAll());
        }

        // GET api/<controller>/5
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            Email email = emailService.GetById(id);
            if (email == null)
            {
                return NotFound();
            }
            return Ok(email);
        }

        // POST api/<controller>
        [HttpPost]
        public IHttpActionResult Post([FromBody]CreateEmailViewModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }
            Email email = new Email
            {
                Address = model.Address
            };

            emailService.Create(email);

            return Ok();
        }

        // PUT api/<controller>/5
        [HttpPut]
        public IHttpActionResult Put(int id, [FromBody]Email model)
        {
            if (model == null)
            {
                return BadRequest();
            }
            if (id != model.Id)
            {
                return BadRequest();
            }

            emailService.Update(model);
            return Ok();
        }

        // DELETE api/<controller>/5
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            emailService.Delete(id);
            return Ok();
        }
    }
}
