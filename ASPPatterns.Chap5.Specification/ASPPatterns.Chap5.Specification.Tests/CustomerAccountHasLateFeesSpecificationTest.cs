using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ASPPatterns.Chap5.Specification.Model;
using NUnit.Framework;

namespace ASPPatterns.Chap5.Specification.Tests
{
    [TestFixture]
    public class CustomerAccountHasLateFeesSpecificationTest
    {
        [Test]
        public void CustomerAccountHasLateFeesSpecification_Should_Be_Satisfied_By_A_Customer_With_Late_Fees()
        {
            CustomerAccount customerWithLateFess = new CustomerAccount() {LateFees = 100};

            CustomerAccountHasLateFeesSpecification specification = new CustomerAccountHasLateFeesSpecification();

            Assert.IsTrue(specification.IsSatisfiedBy(customerWithLateFess));
        }

        [Test]
        public void CustomerAccountHasLateFeesSpecification_Should_Not_Be_Satisfied_By_A_Customer_With_Zero_Late_Fees()
        {
            CustomerAccount customerWithNoLateFess = new CustomerAccount() { LateFees = 0 };

            CustomerAccountHasLateFeesSpecification specification = new CustomerAccountHasLateFeesSpecification();

            Assert.IsFalse(specification.IsSatisfiedBy(customerWithNoLateFess));
        }

        [Test]
        public void CustomerAccountHasLateFeesSpecification_Should_Not_Be_Satisfied_By_A_Customer_With_Late_Fees_When_Used_With_A_NotSpecification()
        {
            CustomerAccount customerWithLateFess = new CustomerAccount() { LateFees = 100 };            

            ISpecification<CustomerAccount> specification = new CustomerAccountHasLateFeesSpecification();

            Assert.IsFalse(specification.Not().IsSatisfiedBy(customerWithLateFess));
        }
    }       
}
