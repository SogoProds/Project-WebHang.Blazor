using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebHang.Data.Data_Interfaces;
using WebHang.Models;

namespace WebHang.Data.Managers
{
    public class GameManager : IGameManager<Game>
    {
        public GameManager(Word wordToBeGuessed)
        {
            WordToBeGuessed = wordToBeGuessed;
            IsWordGuessed = false;
            IsHintUsed = false;
            MistakesLimit = 9;
            Game = new Game(WordToBeGuessed);
            FinalScore = 0.0F;
        }
        
        public bool IsWordGuessed { get; private set; }
        public bool IsHintUsed { get; private set; }
        public byte MistakesLimit { get; private set; }
        public float FinalScore { get; private set; }
        public Word WordToBeGuessed { get; set; }
        public Game Game { get; set; }
        
        public Game Guess(char guess)
        {
            string guessString = new string(guess, 1);
            if (WordToBeGuessed.WordContent.Contains(guessString))
            {
                for (int i = 0; i < Game.GameWordToGuess.Length; i++)
                {
                    if (Game.GameWordHiddenLetters[i] == guess)
                    {
                        return Game;
                    }
                    else if (Game.GameWordToGuess[i] == guess)
                    {
                        var stringHelper = Game.GameWordHiddenLetters.ToCharArray();
                        stringHelper[i] = guess;
                        Game.GameWordHiddenLetters = stringHelper.ToString();
                    }
                }
            }
            else
            {
                Game.GameMistakes++;
            }

            return Game;
        }
        public Game Hint()
        {
            Dictionary<char, byte> lettersFrequency = new Dictionary<char, byte>();
            for (byte i = 0; i < Game.GameWordToGuess.Length - 1; i++)
            {
                var stringHelper = WordToBeGuessed.WordContent[i].ToString();
                if (lettersFrequency.ContainsKey(WordToBeGuessed.WordContent[i]) && !Game.GameWordHiddenLetters.Contains(stringHelper))
                {
                    lettersFrequency[WordToBeGuessed.WordContent[i]]++;
                }
                else
                {
                    lettersFrequency.Add(WordToBeGuessed.WordContent[i], 1);
                }
            }

            byte soughtFrequency = 1;
            while (!lettersFrequency.ContainsValue(soughtFrequency))
            {
                soughtFrequency++;
            }

            List<char> keysWithLowestFrequency = new List<char>();
            foreach (var symbol in lettersFrequency)
            {
                if (symbol.Value == soughtFrequency)
                {
                    keysWithLowestFrequency.Add(symbol.Key);
                }
            }

            var limit = keysWithLowestFrequency.Count();
            Random rnd = new Random();
            int randomId = rnd.Next(limit);

            char randomChar = keysWithLowestFrequency[randomId];
            
            for (byte i = 0; i < Game.GameWordToGuess.Length; i++)
            {
                if (Game.GameWordToGuess[i] == randomChar)
                {
                    var stringHelper = Game.GameWordHiddenLetters.ToCharArray();
                    stringHelper[i] = randomChar;
                    Game.GameWordHiddenLetters = stringHelper.ToString();
                }
            }

            this.IsHintUsed = true;

            return Game;
        }

        public void Score()
        {
            float score = WordToBeGuessed.WordContent.Length;
            switch (WordToBeGuessed.WordDifficulty)
            {
                case WordDifficulties.Easy: score *= 1.0F; break;
                case WordDifficulties.Meduim: score *= 1.5F; break;
                case WordDifficulties.Hard: score *= 2.0F; break;
            }

            if (IsHintUsed == true)
            {
                score *= 0.95F;
            }

            float mistakeModificator = Game.GameMistakes / 10.0F;
            score /= mistakeModificator;

            this.FinalScore = score;
        }
    }
}
