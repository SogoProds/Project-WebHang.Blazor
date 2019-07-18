using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebHang.Data;
using WebHang.Data.Data_Interfaces;
using WebHang.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HangingAPI.Controllers
{
    [Route("api/category")]
    public class CategoryController : Controller
    {
        private readonly ICategoryManager<Category> dataRepository;

        public CategoryController(ICategoryManager<Category> dataRepository)
        {
            this.dataRepository = dataRepository;
        }

        // GET: api/category
        [HttpGet]
        public IActionResult GetAll()
        {
            IEnumerable<Category> categories = dataRepository.GetAll();
            return Ok(categories);
        }

        // GET api/category/5
        [HttpGet("{id}", Name = "GetCategoryById")]
        public IActionResult Get(int id)
        {
            Category category = dataRepository.GetById(id);

            if (category == null)
            {
                return NotFound("The category record could not be found!");
            }
            return Ok(category);
        }

        // POST api/category
        [HttpPost]
        public IActionResult Post([FromBody]Category category)
        {
            if (category == null)
            {
                return BadRequest("Category does not exist!");
            }

            //if model stace vali

            dataRepository.Add(category);
            return CreatedAtRoute(
                "Get",
                new { category.CategoryId },
                category);
        }

        // PUT api/category/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Category category)
        {
            if (category == null)
            {
                return BadRequest("Category does not exist!");
            }

            Category categoryToUpdate = dataRepository.GetById(id);
            if (categoryToUpdate == null)
            {
                return NotFound("The category record could not be found!");
            }

            dataRepository.Update(categoryToUpdate, category);
            return NoContent();
        }

        // DELETE api/category/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Category category = dataRepository.GetById(id);
            if (category == null)
            {
                return NotFound("The category record could not be found!");
            }

            dataRepository.Delete(category);
            return NoContent();
        }
    }
}
