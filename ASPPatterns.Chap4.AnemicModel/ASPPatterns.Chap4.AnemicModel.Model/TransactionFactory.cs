using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPPatterns.Chap4.AnemicModel.Model
{
    public class TransactionFactory
    {
        public static Transaction CreateDepositTransactionFrom(BankAccount bankAccount, Decimal amount, string reference)
        {
            Transaction transDeposit = new Transaction();
            
            transDeposit.Id = Guid.NewGuid();
            transDeposit.BankAccountId = bankAccount.AccountNo;
            transDeposit.Date = DateTime.Now;
            transDeposit.Deposit = amount;
            transDeposit.Reference = reference;

            return transDeposit;
        }

        public static Transaction CreateWithdrawTransactionFrom(BankAccount bankAccount, Decimal amount, string reference)
        {
            Transaction transWithdrawal = new Transaction();
            
            transWithdrawal.Id = Guid.NewGuid();
            transWithdrawal.BankAccountId = bankAccount.AccountNo;
            transWithdrawal.Date = DateTime.Now;
            transWithdrawal.Withdraw = amount;
            transWithdrawal.Reference = reference;

            return transWithdrawal;
        }                
    }
}