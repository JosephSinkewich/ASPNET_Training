using BLL.Services.Interfaces;
using Common.Model;
using System.Web.Http;
using TrnAPI_01.Models;

namespace TrnAPI_01.Controllers
{
    public class RecordController : ApiController
    {
        private readonly IRecordService recordService;

        public RecordController(IRecordService recordService)
        {
            this.recordService = recordService;
        }

        // GET api/<controller>
        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok(recordService.GetAll());
        }

        // GET api/<controller>/5
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            Record record = recordService.GetById(id);
            if (record == null)
            {
                return NotFound();
            }
            return Ok(record);
        }

        // POST api/<controller>
        [HttpPost]
        public IHttpActionResult Post([FromBody]CreateRecordViewModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }
            Record record = new Record
            {
                Name = model.Name,
                CreateDate = model.CreateDate,
                Description = model.Description,
                CategoryId = model.CategoryId,
                PictureId = model.PictureId
            };

            recordService.Create(record);

            return Ok();
        }

        // PUT api/<controller>/5
        [HttpPut]
        public IHttpActionResult Put(int id, [FromBody]Record model)
        {
            if (model == null)
            {
                return BadRequest();
            }
            if (id != model.Id)
            {
                return BadRequest();
            }

            recordService.Update(model);
            return Ok();
        }

        // DELETE api/<controller>/5
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            recordService.Delete(id);
            return Ok();
        }

        [HttpPost]
        [Route("api/record/addevent/{recordId:int},{eventId:int}")]
        public IHttpActionResult AddEvent(int recordId, int eventId)
        {
            recordService.AddEvent(recordId, eventId);
            return Ok();
        }

        [HttpDelete]
        [Route("api/record/removeevent/{recordId:int},{eventId:int}")]
        public IHttpActionResult RemoveEvent(int recordId, int eventId)
        {
            recordService.RemoveEvent(recordId, eventId);
            return Ok();
        }
    }
}
