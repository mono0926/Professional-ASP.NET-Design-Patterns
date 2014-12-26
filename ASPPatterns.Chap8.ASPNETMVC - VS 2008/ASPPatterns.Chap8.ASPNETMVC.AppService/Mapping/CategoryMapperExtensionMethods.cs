using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ASPPatterns.Chap8.ASPNETMVC.AppService.Views;
using ASPPatterns.Chap8.ASPNETMVC.Model;

namespace ASPPatterns.Chap8.ASPNETMVC.AppService.Mapping
{
    public static class CategoryMapperExtensionMethods
    {
        public static IEnumerable<CategoryView> ConvertToCategoryViewList(this IEnumerable<Category> categories)
        {
            IList<CategoryView> categoryViews = new List<CategoryView>();

            foreach (Category c in categories)
            {
                categoryViews.Add(c.ConvertToCategoryView());
            }

            return categoryViews;
        }

        public static CategoryView ConvertToCategoryView(this Category category)
        {
            CategoryView categoryView = new CategoryView();
            categoryView.Name = category.Name;
            categoryView.Id = category.Id;  

            return categoryView;
        }
    }
}
