using NUnit.Framework;
using WebHang.Data.Managers;
using WebHang.Models;

namespace Tests
{
    public class Tests
    {
        [TestFixture]
        public class GameManagerTest
        {
            [Test]
            public void CorrectGuess()
            {
                Word testWord = new Word();
                testWord.WordId = 1;
                testWord.WordDifficulty = WordDifficulties.Easy;
                testWord.WordContent = "oko";
                testWord.WordCategoryId = 1;

                Game testGame = new Game(testWord);
                testGame.GameWordToGuess = "oko";
                testGame.GameWordHiddenLetters = "___";
                GameManager testGameManager = new GameManager(testWord);
                Game guessResult = testGameManager.Guess('k');
                Assert.AreEqual("_k_", guessResult.GameWordHiddenLetters);
                /*Game testGame = new Game(testWord);
                GameManager testGameManager = new GameManager(testWord);
                Game guessResult = testGameManager.Guess(testGame, "k");
                Assert.AreEqual("_k_", guessResult.GameWordHiddenLetters);*/
            }

            [Test]
            public void IncorrectGuess()
            {
                Word testWord = new Word();
                testWord.WordId = 1;
                testWord.WordDifficulty = WordDifficulties.Easy;
                testWord.WordContent = "oko";
                testWord.WordCategoryId = 1;

                Game testGame = new Game(testWord);
                testGame.GameWordToGuess = "oko";
                testGame.GameWordHiddenLetters = "___";
                GameManager testGameManager = new GameManager(testWord);
                Game guessResult = testGameManager.Guess('i');
                Assert.AreEqual("___", guessResult.GameWordHiddenLetters);
                Assert.AreEqual(guessResult.GameMistakes, 1);
                /*Game testGame = new Game(testWord);
                GameManager testGameManager = new GameManager(testWord);
                Game guessResult = testGameManager.Guess(testGame, "k");
                Assert.AreEqual("_k_", guessResult.GameWordHiddenLetters);*/
            }

            [Test]
            public void OnHintUse()
            {
                Word testWord = new Word();
                testWord.WordId = 1;
                testWord.WordDifficulty = WordDifficulties.Easy;
                testWord.WordContent = "tree";
                testWord.WordCategoryId = 1;

                Game testGame = new Game(testWord);
                GameManager testGameManager = new GameManager(testWord);
                Game guessResult = testGameManager.Hint();
                Assert.AreEqual("t____", guessResult.GameWordHiddenLetters);
                /*Game testGame = new Game(testWord);
                GameManager testGameManager = new GameManager(testWord);
                Game guessResult = testGameManager.Guess(testGame, "k");
                Assert.AreEqual("_k_", guessResult.GameWordHiddenLetters);*/
            }
        }
    }
}