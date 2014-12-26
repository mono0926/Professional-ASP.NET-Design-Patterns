using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ASPPatterns.Chap5.Specification.Model;
using NUnit.Framework;

namespace ASPPatterns.Chap5.Specification.Tests
{
    [TestFixture]
    public class AndSpecificationTests
    {
        [Test]
        public void A_Composite_Of_Two_Satisfied_Specifications_Should_Be_Satisfied()
        {
            CustomerAccount customerActive = new CustomerAccount() { AccountActive = true, LateFees = 100 };

            ISpecification<CustomerAccount> specificationActive = new CustomerAccountStillActiveSpecification();
            ISpecification<CustomerAccount> specificationLateFees = new CustomerAccountHasLateFeesSpecification();

            Assert.IsTrue(specificationActive.And(specificationLateFees).IsSatisfiedBy(customerActive));
        }

        [Test]
        public void A_Composite_Of_Two_Specifications_With_Only_One_Satisfied_Should_Be_Satisfied()
        {
            CustomerAccount customerActive = new CustomerAccount() { AccountActive = false, LateFees = 100 };

            ISpecification<CustomerAccount> specificationActive = new CustomerAccountStillActiveSpecification();
            ISpecification<CustomerAccount> specificationLateFees = new CustomerAccountHasLateFeesSpecification();

            Assert.IsFalse(specificationActive.And(specificationLateFees).IsSatisfiedBy(customerActive));
        }

        [Test]
        public void A_Composite_Of_Two_Satisfied_Specifications_Should_Not_Be_Satisfied_When_Used_With_A_NotSpecification()
        {
            CustomerAccount customerActive = new CustomerAccount() { AccountActive = true, LateFees = 100 };

            ISpecification<CustomerAccount> specificationActive = new CustomerAccountStillActiveSpecification();
            ISpecification<CustomerAccount> specificationLateFees = new CustomerAccountHasLateFeesSpecification();

            Assert.IsFalse(specificationActive.And(specificationLateFees).Not().IsSatisfiedBy(customerActive));
        }
    }
}
