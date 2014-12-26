using System.Collections.Generic;

namespace ASPPatterns.Chap9.AjaxTemplates.Model
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> FindAll();
        Category FindBy(int Id);
    }
}
