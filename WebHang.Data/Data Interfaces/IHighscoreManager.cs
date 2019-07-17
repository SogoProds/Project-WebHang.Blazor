using System;
using System.Collections.Generic;
using System.Text;

namespace WebHang.Data.Data_Interfaces
{
    public interface IHighscoreManager<Highscore>
    {
        IEnumerable<Highscore> GetAll();
        IEnumerable<Highscore> Get20TopResultsTotal();
        IEnumerable<Highscore> Get20TopResultsEasy();
        IEnumerable<Highscore> Get20TopResultsMedium();
        IEnumerable<Highscore> Get20TopResultsHard();
        Highscore GetPersonalHighscore(int id);
        Highscore GetById(int id);
        void Add(Highscore highscore);
        void Update(Highscore highscoreToUpdate, Highscore highscore);
        void Delete(Highscore highscore);
    }
}
