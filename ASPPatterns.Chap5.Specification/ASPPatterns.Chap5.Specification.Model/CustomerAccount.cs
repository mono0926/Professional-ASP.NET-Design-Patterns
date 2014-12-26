using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPPatterns.Chap5.Specification.Model
{
    public class CustomerAccount
    {
        private ISpecification<CustomerAccount> _hasReachedRentalThreshold;
        private ISpecification<CustomerAccount> _customerAccountIsActive;
        private ISpecification<CustomerAccount> _customerAccountHasLateFees;

        public CustomerAccount()
        {
            _hasReachedRentalThreshold = new HasReachedRentalThresholdSpecification();
            _customerAccountIsActive = new CustomerAccountStillActiveSpecification();
            _customerAccountHasLateFees = new CustomerAccountHasLateFeesSpecification(); 
        }

        public decimal NumberOfRentalsThisMonth { get; set; }

        public bool AccountActive { get; set; }

        public decimal LateFees { get; set; }

        public bool CanRent()
        {            
            ISpecification<CustomerAccount> canRent = _customerAccountIsActive.And(_hasReachedRentalThreshold.Not()).And(_customerAccountHasLateFees.Not());

            return canRent.IsSatisfiedBy(this);             
        }
    }
}
