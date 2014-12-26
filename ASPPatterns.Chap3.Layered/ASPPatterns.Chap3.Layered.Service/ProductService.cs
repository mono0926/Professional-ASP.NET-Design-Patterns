using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPPatterns.Chap3.Layered.Service
{
    public class ProductService
    {
        private Model.ProductService _productService;

        public ProductService(Model.ProductService ProductService)
        {
            _productService = ProductService;
        }

        public ProductListResponse GetAllProductsFor(ProductListRequest productListRequest)
        {
            ProductListResponse productListResponse = new ProductListResponse();

            try
            {
                IList<Model.Product> productEntities = _productService.GetAllProductsFor(productListRequest.CustomerType);

                productListResponse.Products = productEntities.ConvertToProductListViewModel();
                productListResponse.Success = true;
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                // Log the exception...

                productListResponse.Success = false;
                // Return a friendly error message
                productListResponse.Message = "Check that your database is in the correct place. Hint: Check the AttachDbFilename section within App.config in the project ASPPatterns.Chap3.Layered.Repository.";
            }
            catch (Exception ex)
            {
                // Log the exception...

                productListResponse.Success = false;
                // Return a friendly error message
                productListResponse.Message = "An error occured";
            }

            return productListResponse;
        }

    }
}
