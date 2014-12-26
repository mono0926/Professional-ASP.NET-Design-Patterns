using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPPatterns.Chap8.CoR.Model
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> FindAll();
        Category FindBy(int Id);
    }
}
