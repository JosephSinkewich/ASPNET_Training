using BLL.Services.Interfaces;
using Common.Model;
using System.Collections.Generic;
using System.Web.Http;
using TrnAPI_01.Models;

namespace TrnAPI_01.Controllers
{
    public class CategoryController : ApiController
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        // GET api/<controller>
        [HttpGet]
        public IEnumerable<Category> Get()
        {
            return categoryService.GetAll();
        }

        // GET api/<controller>/5
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            Category category = categoryService.GetById(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }
        //                                                 id not nullable

        // POST api/<controller>
        [HttpPost]
        public IHttpActionResult Post([FromBody]CreateCategoryViewModel model)
        {
            if(model == null)
            {
                return BadRequest();
            }
            Category category = new Category
            {
                Name = model.Name
            };

            categoryService.Create(category);
            
            return Ok();
        }

        // PUT api/<controller>/5
        [HttpPut]
        public IHttpActionResult Put(int id, [FromBody]Category model)
        {
            if (model == null)
            {
                return BadRequest();
            }
            if (id != model.Id)
            {
                return BadRequest();
            }

            categoryService.Update(model);
            return Ok();
        }

        // DELETE api/<controller>/5
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            categoryService.Delete(id);
            return Ok();
        }
    }
}