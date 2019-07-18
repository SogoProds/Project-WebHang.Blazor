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
    [Route("api/highscore")]
    public class HighscoreController : Controller
    {
        private readonly IHighscoreManager<Highscore> dataRepository;

        public HighscoreController(IHighscoreManager<Highscore> dataRepository)
        {
            this.dataRepository = dataRepository;
        }

        // GET: api/highscore
        [HttpGet]
        public IActionResult GetAll()
        {
            IEnumerable<Highscore> highscores = dataRepository.GetAll();
            return Ok(highscores);
        }

        // GET api/highscore/5
        [HttpGet("{id}", Name = "GetHighscoreById")]
        public IActionResult Get(int id)
        {
            Highscore highscore = dataRepository.GetById(id);

            if (highscore == null)
            {
                return NotFound("The highscore record could not be found!");
            }
            return Ok(highscore);
        }

        // POST api/highscore
        [HttpPost]
        public IActionResult Post([FromBody]Highscore highscore)
        {
            if (highscore == null)
            {
                return BadRequest("Highscore does not exist!");
            }

            //if model stace vali

            dataRepository.Add(highscore);
            return CreatedAtRoute(
                "Get",
                new { highscore.HighscoreId },
                highscore);
        }

        // PUT api/highscore/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Highscore highscore)
        {
            if (highscore == null)
            {
                return BadRequest("Highscore does not exist!");
            }

            Highscore highscoreToUpdate = dataRepository.GetById(id);
            if (highscoreToUpdate == null)
            {
                return NotFound("The highscore record could not be found!");
            }

            dataRepository.Update(highscoreToUpdate, highscore);
            return NoContent();
        }

        // DELETE api/highscore/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Highscore highscore = dataRepository.GetById(id);
            if (highscore == null)
            {
                return NotFound("The highscore record could not be found!");
            }

            dataRepository.Delete(highscore);
            return NoContent();
        }
    }
}
