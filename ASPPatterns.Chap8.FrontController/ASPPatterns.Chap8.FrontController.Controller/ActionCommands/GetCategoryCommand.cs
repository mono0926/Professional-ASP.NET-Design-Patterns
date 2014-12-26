using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ASPPatterns.Chap8.FrontController.Controller.Storage;
using ASPPatterns.Chap8.FrontController.Model;
using ASPPatterns.Chap8.FrontController.Controller.Request;

namespace ASPPatterns.Chap8.FrontController.Controller.ActionCommands
{
    public class GetCategoryCommand : IActionCommand 
    {        
        private IViewStorage _storage;
        private ProductService _productService;

        public GetCategoryCommand(IViewStorage storage, ProductService productService)
        {
            _storage = storage;
            _productService = productService;
        }  

        public void Process(WebRequest webRequest)            
        {
            int categoryId = ActionArguments.CategoryId.ExtractFrom(webRequest.QueryArguments);

            Category category = _productService.GetCategoryBy(categoryId);

            _storage.Add(ViewStorageKeys.Category, category);                       
        }      
     
    }
}
