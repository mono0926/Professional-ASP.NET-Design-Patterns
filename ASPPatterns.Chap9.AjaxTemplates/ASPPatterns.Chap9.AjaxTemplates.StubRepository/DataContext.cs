using System;
using System.Collections.Generic;
using ASPPatterns.Chap9.AjaxTemplates.Model;

namespace ASPPatterns.Chap9.AjaxTemplates.StubRepository
{
    public class DataContext
    {
        private List<Product> _products;
        private List<Category> _categories;

        public DataContext()
        {
            Brand brandX = new Brand { Id = 1, Name = "Brand X" };
            Brand brandY = new Brand { Id = 2, Name = "Brand Y" };

            _categories = new List<Category>();

            Category hatCategory = new Category { Id = 1, Name = "Hats" };
            Category gloveCategory = new Category { Id = 2, Name = "Gloves" };
            Category scarfCategory = new Category { Id = 3, Name = "Scarfs" };

            _categories.Add(hatCategory);
            _categories.Add(gloveCategory);
            _categories.Add(scarfCategory);

            _products = new List<Product>();
            _products.Add(new Product { Id = 1, Name = "BaseBall Cap", Price = 9.99m, Category = hatCategory, Brand = brandX });
            _products.Add(new Product { Id = 2, Name = "Flat Cap", Price = 5.99m, Category = hatCategory, Brand = brandX });
            _products.Add(new Product { Id = 3, Name = "Top Hat", Price = 6.99m, Category = hatCategory, Brand = brandY });

            _products.Add(new Product { Id = 4, Name = "Mitten", Price = 10.99m, Category = gloveCategory, Brand = brandY });
            _products.Add(new Product { Id = 5, Name = "Fingerless Glove", Price = 13.99m, Category = gloveCategory, Brand = brandY });
            _products.Add(new Product { Id = 6, Name = "Leather Glove", Price = 7.99m, Category = gloveCategory, Brand = brandX });

            _products.Add(new Product { Id = 7, Name = "Silk Scarf", Price = 23.99m, Category = scarfCategory, Brand = brandY });
            _products.Add(new Product { Id = 8, Name = "Woollen", Price = 14.99m, Category = scarfCategory, Brand = brandX });
        }

        public List<Product> Products
        {
            get { return _products; }
        }

        public List<Category> Categories
        {
            get { return _categories; }
        }
    }
}
