using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebHang.Models;

namespace WebHang.Data.Managers
{
    public class HighscoreManager : IDataRepositoryCommon<Highscore>
    {
        readonly DBContext dbContext;

        public HighscoreManager(DBContext dBContext)
        {
            this.dbContext = dBContext;
        }

        public IEnumerable<Highscore> GetAll()
        {
            return dbContext.Highscores.ToList();
        }
        //Might add later
        /*
        public IEnumerable<Highscore> GetHighscoresByDifficulty(string difficulty)
        {
            if (difficulty == "Easy")
            {

            }
        }*/
        public Highscore GetById(int id)
        {
            return dbContext.Highscores.Find(id);
        }
        public void Add(Highscore highscore)
        {
            dbContext.Highscores.Add(highscore);
            dbContext.SaveChanges();
        }
        public void Update(Highscore highscoreToUpdate, Highscore highscore)
        {
            highscoreToUpdate.HighscoreEasy = highscore.HighscoreEasy;
            highscoreToUpdate.HighscoreMedium = highscore.HighscoreMedium;
            highscoreToUpdate.HighscoreHard = highscore.HighscoreHard;
            highscoreToUpdate.HighscoreTotal = highscore.HighscoreTotal;

            dbContext.SaveChanges();
        }
        public void Delete(Highscore highscore)
        {
            dbContext.Highscores.Remove(highscore);
            dbContext.SaveChanges();
        }
    }
}
