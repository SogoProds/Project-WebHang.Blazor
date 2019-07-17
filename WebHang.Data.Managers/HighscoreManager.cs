using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebHang.Data.Data_Interfaces;
using WebHang.Models;

namespace WebHang.Data.Managers
{
    public class HighscoreManager : IHighscoreManager<Highscore>
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
        public IEnumerable<Highscore> Get20TopResultsTotal()
        {
            return dbContext.Highscores.OrderByDescending(x => x.HighscoreTotal).Take(20);
        }
        public IEnumerable<Highscore> Get20TopResultsEasy()
        {
            return dbContext.Highscores.OrderByDescending(x => x.HighscoreEasy).Take(20);
        }
        public IEnumerable<Highscore> Get20TopResultsMedium()
        {
            return dbContext.Highscores.OrderByDescending(x => x.HighscoreMedium).Take(20);
        }
        public IEnumerable<Highscore> Get20TopResultsHard()
        {
            return dbContext.Highscores.OrderByDescending(x => x.HighscoreHard).Take(20);
        }
        public Highscore GetPersonalHighscore(int id)
        {
            var personalHighscore = dbContext.Highscores.Where(x => x.HighscorePlayerId == id).ToList();
            return personalHighscore[0];
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
