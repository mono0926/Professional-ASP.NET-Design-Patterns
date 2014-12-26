using System;
using System.Collections.Generic;
using System.Linq;
using ASPPatterns.Chap9.AjaxTemplates.Model;

namespace ASPPatterns.Chap9.AjaxTemplates.Controllers
{
    public class CategoryBrandViewMapper
    {
        public static List<CategoryBrandView> GetCategoryBrandViews(IEnumerable<Category> categories)
        {
            return GetCategoryBrandViews(0, categories, null);
        }

        public static  List<CategoryBrandView> GetCategoryBrandViews(int categoryId, IEnumerable<Category> categories, IEnumerable<Product> products)
        {
            List<CategoryBrandView> categoryBrandViews = new List<CategoryBrandView>();

            foreach (Category cat in categories)
            {
                CategoryBrandView categoryBrandView = new CategoryBrandView { Name = cat.Name, CategoryId = cat.Id, Brands = new List<Brand>() };

                if (cat.Id == categoryId)
                    categoryBrandView.Brands = (from p in products
                                                group p by p.Brand into b
                                                select b.Key as Brand).ToList<Brand>();

                categoryBrandViews.Add(categoryBrandView);
            }
            return categoryBrandViews;
        }
    }
}
