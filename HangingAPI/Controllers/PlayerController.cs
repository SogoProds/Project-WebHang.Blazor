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
    [Route("api/player")]
    public class PlayerController : Controller
    {
        private readonly IPlayerManager<Player> dataRepository;

        public PlayerController(IPlayerManager<Player> dataRepository)
        {
            this.dataRepository = dataRepository;
        }

        // GET: api/player
        [HttpGet(Name = "GetAllPlayers")]
        public IActionResult GetAll()
        {
            IEnumerable<Player> players = dataRepository.GetAll();
            return Ok(players);
        }

        // GET api/player/5
        [HttpGet("{id}", Name = "GetPlayerById")]
        public IActionResult Get(int id)
        {
            Player player = dataRepository.GetById(id);

            if (player == null)
            {
                return NotFound("The player record could not be found!");
            }
            return Ok(player);
        }

        // POST api/player
        [HttpPost]
        public IActionResult Post([FromBody]Player player)
        {
            if (player == null)
            {
                return BadRequest("Player does not exist!");
            }

            //if model stace vali

            dataRepository.Add(player);
            return CreatedAtRoute(
                "Get",
                new { player.PlayerId },
                player);
        }

        // PUT api/player/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Player player)
        {
            if (player == null)
            {
                return BadRequest("Player does not exist!");
            }

            Player playerToUpdate = dataRepository.GetById(id);
            if (playerToUpdate == null)
            {
                return NotFound("The player record could not be found!");
            }

            dataRepository.Update(playerToUpdate, player);
            return NoContent();
        }

        // DELETE api/player/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Player player = dataRepository.GetById(id);
            if (player == null)
            {
                return NotFound("The player record could not be found!");
            }

            dataRepository.Delete(player);
            return NoContent();
        }
    }
}
