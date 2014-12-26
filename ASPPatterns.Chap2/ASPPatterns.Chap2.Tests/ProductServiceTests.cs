using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using ASPPatterns.Chap2.Service;
using ASPPatterns.Chap2.Tests.Stubs;
using ASPPatterns.Chap2.Tests.Mocks;

namespace ASPPatterns.Chap2.Tests
{
    [TestFixture]
    public class ProductServiceTests
    {
        [Test]        
        public void A_ProductService_Should_Retrieve_From_The_Cache_The_Second_Time_The_Method_Is_Called_With_The_Same_Argumengts()
        {
            MockCacheStorage mockCacheStorage = new MockCacheStorage();
            StubProductRepository stubProductRepository = new StubProductRepository();
            int categoryId = 1;
            ProductService productService = new ProductService(stubProductRepository, mockCacheStorage);

            productService.GetAllProductsIn(categoryId);
            Assert.AreEqual(0, mockCacheStorage.RetrievedFromCacheCount());

            productService.GetAllProductsIn(categoryId);
            Assert.AreEqual(1, mockCacheStorage.RetrievedFromCacheCount());

        }

        [Test]
        public void A_Null_Object_Caching_Adapter_Will_Prevent_Any_Data_Caching()
        {
            MockProductRepository mockProductRepository = new MockProductRepository();
            NullObjectCachingAdapter nullObjectCachingAdapter = new NullObjectCachingAdapter();
            int categoryId = 1;
            ProductService productService = new ProductService(mockProductRepository, nullObjectCachingAdapter);

            productService.GetAllProductsIn(categoryId);
            Assert.AreEqual(1, mockProductRepository.NumberOfTimesCalled());

            productService.GetAllProductsIn(categoryId);
            Assert.AreEqual(2, mockProductRepository.NumberOfTimesCalled());
        }
    }
}
