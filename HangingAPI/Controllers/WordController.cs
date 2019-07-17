using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebHang.Data;
using WebHang.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HangingAPI.Controllers
{
    [Route("api/word")]
    public class WordController : Controller
    {
        private readonly IDataRepositoryCommon<Word> dataRepository;

        public WordController(IDataRepositoryCommon<Word> dataRepository)
        {
            this.dataRepository = dataRepository;
        }

        // GET: api/word
        [HttpGet]
        public IActionResult GetAll()
        {
            IEnumerable<Word> words = dataRepository.GetAll();
            return Ok(words);
        }

        // GET api/word/5
        [HttpGet("{id}", Name = "GetWordById")]
        public IActionResult Get(int id)
        {
            Word word = dataRepository.GetById(id);

            if (word == null)
            {
                return NotFound("The word record could not be found!");
            }
            return Ok(word);
        }

        // POST api/word
        [HttpPost]
        public IActionResult Post([FromBody]Word word)
        {
            if (word == null)
            {
                return BadRequest("Word does not exist!");
            }

            //if model state vali

            dataRepository.Add(word);
            return CreatedAtRoute(
                "Get",
                new { word.WordId },
                word);
        }

        // PUT api/word/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Word word)
        {
            if (word == null)
            {
                return BadRequest("Word does not exist!");
            }

            Word wordToUpdate = dataRepository.GetById(id);
            if (wordToUpdate == null)
            {
                return NotFound("The word record could not be found!");
            }

            dataRepository.Update(wordToUpdate, word);
            return NoContent();
        }

        // DELETE api/word/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Word word = dataRepository.GetById(id);
            if (word == null)
            {
                return NotFound("The word record could not be found!");
            }

            dataRepository.Delete(word);
            return NoContent();
        }
    }
}
