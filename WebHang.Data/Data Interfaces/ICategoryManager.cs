using System;
using System.Collections.Generic;
using System.Text;

namespace WebHang.Data.Data_Interfaces
{
    public interface ICategoryManager<Category>
    {
        IEnumerable<Category> GetAll();
        Category GetById(int id);
        void Add(Category category);
        void Update(Category categoryToUpdate, Category category);
        void Delete(Category category);
    }
}
