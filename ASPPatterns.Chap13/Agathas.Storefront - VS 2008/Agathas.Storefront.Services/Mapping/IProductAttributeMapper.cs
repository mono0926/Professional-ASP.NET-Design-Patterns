using System;
using System.Collections.Generic;
using Agathas.Storefront.Model.Products;
using Agathas.Storefront.Services.ViewModels;
using AutoMapper;

namespace Agathas.Storefront.Services.Mapping
{
    public static class IProductAttributeMapper
    {
        public static RefinementGroup ConvertToRefinementGroup(
                                this IEnumerable<IProductAttribute> productAttributes,
                                RefinementGroupings refinementGroupType)
        {
            RefinementGroup refinementGroup = new RefinementGroup()
            {
                Name = refinementGroupType.ToString(),
                GroupId = (int)refinementGroupType
            };

            refinementGroup.Refinements =
                      Mapper.Map<IEnumerable<IProductAttribute>, IEnumerable<Refinement>>
                                                                     (productAttributes);

            return refinementGroup;
        }
    }

}
