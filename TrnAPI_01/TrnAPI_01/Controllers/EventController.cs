using BLL.Services.Interfaces;
using Common.Model;
using System.Collections.Generic;
using System.Web.Http;
using TrnAPI_01.Models;

namespace TrnAPI_01.Controllers
{
    public class EventController : ApiController
    {
        private readonly IEventService eventService;

        public EventController(IEventService eventService)
        {
            this.eventService = eventService;
        }

        // GET api/<controller>
        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok(eventService.GetAll());
        }

        // GET api/<controller>/5
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            Event eventInst = eventService.GetById(id);
            if (eventInst == null)
            {
                return NotFound();
            }
            return Ok(eventInst);
        }

        // POST api/<controller>
        [HttpPost]
        public IHttpActionResult Post([FromBody]CreateEventViewModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }
            Event eventInst = new Event
            {
                Name = model.Name
            };

            eventService.Create(eventInst);

            return Ok();
        }

        // PUT api/<controller>/5
        [HttpPut]
        public IHttpActionResult Put(int id, [FromBody]Event model)
        {
            if (model == null)
            {
                return BadRequest();
            }
            if (id != model.Id)
            {
                return BadRequest();
            }

            eventService.Update(model);
            return Ok();
        }

        // DELETE api/<controller>/5
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            eventService.Delete(id);
            return Ok();
        }

        [HttpGet]
        [Route("api/event/getbyrecordid/{recordId:int}")]
        public IHttpActionResult GetByRecordId(int recordId)
        {
            IEnumerable<Event> events = eventService.GetEventsByRecordId(recordId);

            return Ok(events);
        }
    }
}
