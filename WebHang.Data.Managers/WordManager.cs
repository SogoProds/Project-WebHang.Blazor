using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebHang.Models;

namespace WebHang.Data.Managers
{
    public class WordManager : IDataRepositoryCommon<Word>
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
        public IEnumerable<Word> GetWordsByCategoryId(int id)
        {
            return dbContext.Words.Where(x => x.WordCategoryId == id).ToList();
        }
        /*public IEnumerable<Word> GetWordsByDifficulty(string difficulty)
        {
            return dbContext.Words.Where(x => x.WordDifficulty == difficulty).ToList();
        }*/
        public Word GetById(int id)
        {
            return dbContext.Words.Find(id);
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
    }
}
