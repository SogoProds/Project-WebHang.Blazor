using System;
using System.Collections.Generic;
using System.Text;

namespace WebHang.Data.Data_Interfaces
{
    public interface IWordManager<Word>
    {
        IEnumerable<Word> GetAll();
        Word GetById(int id);
        Word GetRandomWord();
        Word GetRandomWord(int categoryId);
        Word GetRandomWord(string difficulty);
        Word GetRandomWord(int categoryId, string difficulty);
        void Add(Word word);
        void Update(Word wordToUpdate, Word word);
        void Delete(Word word);
    }
}
