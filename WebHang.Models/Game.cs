using System;
using System.Collections.Generic;
using System.Text;

namespace WebHang.Models
{
    public class Game
    {
        public Game()
        {

        }
        public Game(Word word)
        {
            GameWordToGuess = word.WordContent;
            GameWordHiddenLetters = new string('_', GameWordToGuess.Length);
            GameMistakes = 0;
            GameFinished = false;
            GameHintAvailable = true;
        }
        public string GameWordToGuess { get; set; }
        public string GameWordHiddenLetters { get; set; }
        public int GameMistakes { get; set; }
        public bool GameFinished { get; set; }
        public bool GameHintAvailable { get; set; }
    }
}
