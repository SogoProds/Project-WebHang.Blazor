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
            CurrentGame = new Game(WordToBeGuessed);
            FinalScore = 0.0F;
        }
        
        public bool IsWordGuessed { get; private set; }
        public bool IsHintUsed { get; private set; }
        public byte MistakesLimit { get; private set; }
        public float FinalScore { get; private set; }
        public Word WordToBeGuessed { get; set; }
        public Game CurrentGame { get; set; }
        
        public Game Guess(char guess)
        {
            if (CurrentGame.GameWordToGuess.Contains(guess))
            {
                for (int i = 0; i < CurrentGame.GameWordToGuess.Length; i++)
                {
                    if (CurrentGame.GameWordHiddenLetters[i] == guess)
                    {
                        return CurrentGame;
                    }
                    if (CurrentGame.GameWordToGuess[i] == guess)
                    {
                        StringBuilder stringHelper = new StringBuilder(CurrentGame.GameWordHiddenLetters);
                        stringHelper[i] = guess;
                        CurrentGame.GameWordHiddenLetters = stringHelper.ToString();
                    }
                }
            }
            else
            {
                CurrentGame.GameMistakes++;
            }

            return CurrentGame;
        }
        public Game Hint()
        {
            Dictionary<char, byte> lettersFrequency = new Dictionary<char, byte>();
            for (byte i = 0; i < CurrentGame.GameWordToGuess.Length - 1; i++)
            {
                var stringHelper = WordToBeGuessed.WordContent[i].ToString();
                if (lettersFrequency.ContainsKey(WordToBeGuessed.WordContent[i]) && !CurrentGame.GameWordHiddenLetters.Contains(stringHelper))
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
            
            for (byte i = 0; i < CurrentGame.GameWordToGuess.Length; i++)
            {
                if (CurrentGame.GameWordToGuess[i] == randomChar)
                {
                    StringBuilder stringHelper = new StringBuilder(CurrentGame.GameWordHiddenLetters);
                    stringHelper[i] = randomChar;
                    CurrentGame.GameWordHiddenLetters = stringHelper.ToString();
                }
            }

            this.IsHintUsed = true;

            return CurrentGame;
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

            float mistakeModificator = CurrentGame.GameMistakes / 10.0F;
            score /= mistakeModificator;

            this.FinalScore = score;
        }
        public Game Start()
        {
            DBContext dBContext = new DBContext();
            List<Word> filteredWords = dBContext.Words.ToList();
            Random rnd = new Random();
            Word word = filteredWords[rnd.Next(filteredWords.Count())];

            Game game = new Game(word);
            return game;
        }
    }
}
