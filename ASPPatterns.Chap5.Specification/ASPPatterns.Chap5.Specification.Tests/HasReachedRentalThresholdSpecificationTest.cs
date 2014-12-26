using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ASPPatterns.Chap5.Specification.Model;
using NUnit.Framework;

namespace ASPPatterns.Chap5.Specification.Tests
{
    [TestFixture]
    public class HasReachedRentalThresholdSpecificationTest
    {
        [Test]
        public void HasReachedRentalThresholdSpecification_Should_Be_Satisfied_By_A_Customer_Who_Has_Made_5_Rentals_This_Month()
        {
            CustomerAccount customerWith5RentalsThisMonth = new CustomerAccount() { NumberOfRentalsThisMonth  = 5 };

            HasReachedRentalThresholdSpecification specification = new HasReachedRentalThresholdSpecification();

            Assert.IsTrue(specification.IsSatisfiedBy(customerWith5RentalsThisMonth));
        }

        [Test]
        public void HasReachedRentalThresholdSpecification_Should_NoBe_Satistfied_By_A_Customer_Who_Has_Made_Less_Than_5_Rentals_This_Month()
        {
            CustomerAccount customerWith5RentalsThisMonth = new CustomerAccount() { NumberOfRentalsThisMonth = 1 };

            HasReachedRentalThresholdSpecification specification = new HasReachedRentalThresholdSpecification();

            Assert.IsFalse(specification.IsSatisfiedBy(customerWith5RentalsThisMonth));
        }
    }
}
