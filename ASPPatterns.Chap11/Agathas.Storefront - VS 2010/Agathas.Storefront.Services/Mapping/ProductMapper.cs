using System.Collections.Generic;
using System.Linq;
using Agathas.Storefront.Model.Products;
using Agathas.Storefront.Services.Messaging.ProductCatalogService;
using Agathas.Storefront.Services.ViewModels;

namespace Agathas.Storefront.Services.Mapping
{
    public static class ProductMapper
    {
        public static GetProductsByCategoryResponse CreateProductSearchResultFrom(this IEnumerable<Product> productsMatchingRefinement, GetProductsByCategoryRequest request)
        {
            GetProductsByCategoryResponse productSearchResultView = new GetProductsByCategoryResponse();

            IEnumerable<ProductTitle> productsFound = productsMatchingRefinement.Select(p => p.Title).Distinct();

            productSearchResultView.SelectedCategory = request.CategoryId;

            productSearchResultView.NumberOfTitlesFound = productsFound.Count();

            productSearchResultView.TotalNumberOfPages = NoOfResultPagesGiven(request.NumberOfResultsPerPage,
                                                                              productSearchResultView.NumberOfTitlesFound);

            productSearchResultView.RefinementGroups = GenerateAvailableProductRefinementsFrom(productsFound);

            productSearchResultView.Products = CropProductListToSatisfyGivenIndex(request.Index, request.NumberOfResultsPerPage, productsFound);

            return productSearchResultView;
        }

        private static IEnumerable<ProductSummaryView> CropProductListToSatisfyGivenIndex(int pageIndex, int numberOfResultsPerPage, IEnumerable<ProductTitle> productsFound)
        {
            if (pageIndex > 1)
            {
                int numToSkip = (pageIndex - 1) * numberOfResultsPerPage;
                return productsFound.Skip(numToSkip).Take(numberOfResultsPerPage).ConvertToProductViews();
            }
            else
                return productsFound.Take(numberOfResultsPerPage).ConvertToProductViews();
        }

        private static int NoOfResultPagesGiven(int numberOfResultsPerPage, int numberOfTitlesFound)
        {
            if (numberOfTitlesFound < numberOfResultsPerPage)
                return 1;
            else
            {
                return (numberOfTitlesFound / numberOfResultsPerPage) + (numberOfTitlesFound % numberOfResultsPerPage);
            }
        }

        private static IList<RefinementGroup> GenerateAvailableProductRefinementsFrom(IEnumerable<ProductTitle> productsFound)
        {
            var brandsRefinementGroup = productsFound.Select(p => p.Brand).Distinct().ToList()
                                       .ConvertAll<IProductAttribute>(b => (IProductAttribute)b).ConvertToRefinementGroup(RefinementGroupings.brand);
            var colorsRefinementGroup = productsFound.Select(p => p.Color).Distinct().ToList()
                                       .ConvertAll<IProductAttribute>(c => (IProductAttribute)c).ConvertToRefinementGroup(RefinementGroupings.color);
            var sizesRefinementGroup = (from p in productsFound
                                        from si in p.Products
                                        select si.Size).Distinct().ToList()
                                       .ConvertAll<IProductAttribute>(s => (IProductAttribute)s).ConvertToRefinementGroup(RefinementGroupings.size);

            IList<RefinementGroup> refinementGroups = new List<RefinementGroup>();

            refinementGroups.Add(brandsRefinementGroup);
            refinementGroups.Add(colorsRefinementGroup);
            refinementGroups.Add(sizesRefinementGroup);
            return refinementGroups;
        }
    }
}