using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ASPPatterns.Chap8.FrontController.Model;

namespace ASPPatterns.Chap8.FrontController.StubRepository
{
    public class CategoryRepository : ICategoryRepository
    {
        public IEnumerable<Category> FindAll()
        {
            return new DataContext().Categories;
        }

        public Category FindBy(int Id)
        {
            return new DataContext().Categories.FirstOrDefault(cat => cat.Id == Id);
        }
    }
}
