using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ASPPatterns.Chap5.Specification.Model;
using NUnit.Framework;

namespace ASPPatterns.Chap5.Specification.Tests
{
    [TestFixture]
    public class CustomerAccountStillActiveSpecificationTest
    {
        [Test]
        public void CustomerAccountStillActiveSpecification_Should_Be_Satisfied_By_An_Active_Customer()
        {
            CustomerAccount customerActive = new CustomerAccount() { AccountActive  = true };

            CustomerAccountStillActiveSpecification specification = new CustomerAccountStillActiveSpecification();

            Assert.IsTrue(specification.IsSatisfiedBy(customerActive));
        }

        [Test]
        public void CustomerAccountStillActiveSpecification_Should_Not_Be_Satisfied_By_A_Customer_Who_Is_Not_Active()
        {
            CustomerAccount customerNotActive = new CustomerAccount() { AccountActive = false };

            CustomerAccountStillActiveSpecification specification = new CustomerAccountStillActiveSpecification();

            Assert.IsFalse(specification.IsSatisfiedBy(customerNotActive));
        }

        [Test]
        public void CustomerAccountStillActiveSpecification_Should_Not_Be_Satisfied_By_An_Active_Customer_When_Used_With_A_NotSpecification()
        {
            CustomerAccount customerActive = new CustomerAccount() { AccountActive = true };

            ISpecification<CustomerAccount> specification = new CustomerAccountStillActiveSpecification();

            Assert.IsFalse(specification.Not().IsSatisfiedBy(customerActive));
        }

    }
}
