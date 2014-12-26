using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ASPPatterns.Chap5.LayerSuperType.Model;
using NUnit.Framework;

namespace ASPPatterns.Chap5.LayerSuperType.Tests
{
    [TestFixture]
    public class EntityBaseTests
    {
        [Test]
        public void A_Product_Should_Start_Valid()
        {
            Product p = new Product(System.Guid.NewGuid());

            Assert.IsTrue(p.IsValid());
        }

        [Test]
        [ExpectedException(typeof(ApplicationException))]
        public void A_Product_Will_Throw_An_Exception_If_You_Try_And_Change_Its_Id()
        {
            Product p = new Product(Guid.NewGuid());
            p.Id = Guid.NewGuid();
            
        }
    }
}
