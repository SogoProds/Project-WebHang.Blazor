using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebHang.Data.Data_Interfaces;
using WebHang.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HangingAPI.Controllers
{
    [Route("api/game")]
    public class GameController : Controller
    {
        private readonly IGameManager<Game> dataRepository;

        public GameController(IGameManager<Game> dataRepository)
        {
            this.dataRepository = dataRepository;
        }

        [Route("Start")]
        [HttpGet]
        public IActionResult Start()
        {
            return Ok(dataRepository.Start());
        }
        [HttpPost("{guess}", Name = "Guess")]
        public IActionResult Guess(char guess)
        {
            Game game = new Game();
            game = dataRepository.Guess(guess);
            return Ok(game);
        }
    }
}
