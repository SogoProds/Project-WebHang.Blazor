using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebHang.Models;

namespace WebHang.Data.Managers
{
    public class CategoryManager : IDataRepositoryCommon<Category>
    {
        readonly DBContext dbContext;

        public CategoryManager(DBContext dBContext)
        {
            this.dbContext = dBContext;
        }

        public IEnumerable<Category> GetAll()
        {
            return dbContext.Categories.ToList();
        }
        public Category GetById(int id)
        {
            return dbContext.Categories.Find(id);
        }
        public void Add(Category category)
        {
            dbContext.Categories.Add(category);
            dbContext.SaveChanges();
        }
        public void Update(Category categoryToUpdate, Category category)
        {
            categoryToUpdate.CategoryName = category.CategoryName;
            dbContext.SaveChanges();
        }
        public void Delete(Category category)
        {
            dbContext.Categories.Remove(category);
            dbContext.SaveChanges();
        }
    }
}
