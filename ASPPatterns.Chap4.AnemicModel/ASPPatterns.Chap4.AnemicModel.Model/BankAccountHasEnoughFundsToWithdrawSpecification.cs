using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPPatterns.Chap4.AnemicModel.Model
{
    public class BankAccountHasEnoughFundsToWithdrawSpecification
    {
        private decimal _amountToWithdraw;

        public BankAccountHasEnoughFundsToWithdrawSpecification(decimal amountToWithdraw)
        {
            _amountToWithdraw = amountToWithdraw;
        }

        public bool IsSatisfiedBy(BankAccount bankAccount)
        {
            return bankAccount.Balance >= _amountToWithdraw;
        }
    }
}
