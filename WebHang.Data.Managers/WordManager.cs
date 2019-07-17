using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebHang.Data.Data_Interfaces;
using WebHang.Models;

namespace WebHang.Data.Managers
{
    public class WordManager : IWordManager<Word>
    {
        readonly DBContext dbContext;

        public WordManager(DBContext dBContext)
        {
            this.dbContext = dBContext;
        }

        public IEnumerable<Word> GetAll()
        {
            return dbContext.Words.ToList();
        }   
        public Word GetById(int id)
        {
            return dbContext.Words.Find(id);
        }
        public Word GetRandomWord()
        {
            var suitableWords = GetAll().ToList();
            return suitableWords[Randomizer(suitableWords)];
        }
        public Word GetRandomWord(int categoryId)
        {
            var words = GetAll();
            var suitableWords = words.Where(x => x.WordCategoryId == categoryId).ToList();

            return suitableWords[Randomizer(suitableWords)];
        }
        public Word GetRandomWord(string difficulty)
        {
            var words = GetAll();
            List<Word> suitableWords = DifficultyFilter(words, difficulty);
            
            return suitableWords[Randomizer(suitableWords)];
        }
        public Word GetRandomWord(int categoryId, string difficulty)
        {
            var words = GetAll();
            var wordsFiltered = words.Where(x => x.WordCategoryId == categoryId);

            List<Word> suitableWords = DifficultyFilter(wordsFiltered, difficulty);

            return suitableWords[Randomizer(suitableWords)];
        }
        public void Add(Word word)
        {
            dbContext.Words.Add(word);
            dbContext.SaveChanges();
        }
        public void Update(Word wordToUpdate, Word word)
        {
            wordToUpdate.WordContent = word.WordContent;
            wordToUpdate.WordDifficulty = word.WordDifficulty;
            wordToUpdate.WordCategoryId = word.WordCategoryId;

            dbContext.SaveChanges();
        }
        public void Delete(Word word)
        {
            dbContext.Words.Remove(word);
            dbContext.SaveChanges();
        }

        private int Randomizer(List<Word> words)
        {
            var limit = words.Count();

            Random rnd = new Random();
            int randomId = rnd.Next(limit);

            return randomId;
        }
        private List<Word> DifficultyFilter(IEnumerable<Word> words, string difficulty)
        {
            List<Word> suitableWords = new List<Word>();
            foreach (var duma in words)
            {
                if (Enum.TryParse(difficulty, out WordDifficulties inputDifficulty))
                {
                    if (duma.WordDifficulty == inputDifficulty)
                    {
                        suitableWords.Add(duma);
                    }
                }
            }

            return suitableWords;
        }
    }
}
