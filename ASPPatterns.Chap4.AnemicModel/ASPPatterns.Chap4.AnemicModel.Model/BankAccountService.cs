using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPPatterns.Chap4.AnemicModel.Model
{
    public class BankAccountService
    {
        private IBankAccountRepository _bankAccountRepository;

        public BankAccountService(IBankAccountRepository bankAccountRepository)
        {
            _bankAccountRepository = bankAccountRepository;            
        }

        public BankAccount CreateBankAccount(string CustomerName)
        {
            BankAccount bankAccount = new BankAccount();

            bankAccount.AccountNo = Guid.NewGuid();
            bankAccount.CustomerRef = CustomerName;

            Transaction openingTransaction = TransactionFactory.CreateDepositTransactionFrom(bankAccount, 0, "account created");

            bankAccount.Transactions.Add(openingTransaction);

            _bankAccountRepository.Add(bankAccount);

            return bankAccount;
        }
        
        public void Transfer(Guid accountNoTo, Guid accountNoFrom, decimal amount)
        {
            BankAccount bankAccountTo = _bankAccountRepository.FindBy(accountNoTo);
            BankAccount bankAccountFrom = _bankAccountRepository.FindBy(accountNoFrom);

            BankAccountHasEnoughFundsToWithdrawSpecification HasEnoughFunds = new BankAccountHasEnoughFundsToWithdrawSpecification(amount);

            if (HasEnoughFunds.IsSatisfiedBy(bankAccountFrom))
            {
                bankAccountTo.Balance += amount;
                Transaction transDeposit = TransactionFactory.CreateDepositTransactionFrom(bankAccountTo, amount, "From Acc " + bankAccountFrom.CustomerRef + " ");
                bankAccountTo.Transactions.Add(transDeposit);
                
                bankAccountFrom.Balance -= amount;
                Transaction transWithdraw = TransactionFactory.CreateWithdrawTransactionFrom(bankAccountFrom, amount, "Transfer To Acc " + bankAccountTo.CustomerRef + " ");
                bankAccountFrom.Transactions.Add(transWithdraw);

                _bankAccountRepository.Save(bankAccountTo);
                _bankAccountRepository.Save(bankAccountFrom);                
            }
            else
            {
                throw new InsufficientFundsException();
            }
        }

        public void Withdraw(Guid accountNo, decimal amount, string reference)        
        {
            BankAccount bankAccount = _bankAccountRepository.FindBy(accountNo);

            BankAccountHasEnoughFundsToWithdrawSpecification HasEnoughFunds = new BankAccountHasEnoughFundsToWithdrawSpecification(amount);

            if (HasEnoughFunds.IsSatisfiedBy(bankAccount))
            {
                bankAccount.Balance -= amount;
                Transaction transWithdraw = TransactionFactory.CreateWithdrawTransactionFrom(bankAccount, amount, reference);
                bankAccount.Transactions.Add(transWithdraw);

                _bankAccountRepository.Save(bankAccount);
            }
        }

        public void Deposit(Guid accountNo, decimal amount, string reference)
        {
            BankAccount bankAccount = _bankAccountRepository.FindBy(accountNo);

            bankAccount.Balance += amount;
            Transaction transDeposit = TransactionFactory.CreateDepositTransactionFrom(bankAccount, amount, reference);
            bankAccount.Transactions.Add(transDeposit);

            _bankAccountRepository.Save(bankAccount);            
        }
    }
}
