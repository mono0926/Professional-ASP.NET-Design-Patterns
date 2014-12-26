using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ASPPatterns.Chap4.DomainModel.Model;
using ASPPatterns.Chap4.DomainModel.Repository;
using ASPPatterns.Chap4.DomainModel.AppService.Messages;

namespace ASPPatterns.Chap4.DomainModel.AppService
{
    public class ApplicationBankAccountService
    {
        private BankAccountService _bankAccountService;
        private IBankAccountRepository _bankRepository;

        public ApplicationBankAccountService() : 
            this (new BankAccountRepository(), new BankAccountService(new BankAccountRepository()))
        { }

        public ApplicationBankAccountService(IBankAccountRepository bankRepository, BankAccountService bankAccountService)
        {
            _bankRepository = bankRepository;
            _bankAccountService = bankAccountService;
        }

        public ApplicationBankAccountService(BankAccountService bankAccountService, IBankAccountRepository bankRepository)
        {
            _bankAccountService = bankAccountService;
            _bankRepository = bankRepository;
        }

        public BankAccountCreateResponse CreateBankAccount(BankAccountCreateRequest bankAccountCreateRequest)
        { 
            BankAccountCreateResponse bankAccountCreateResponse = new BankAccountCreateResponse();
            BankAccount bankAccount = new BankAccount();

            bankAccount.CustomerRef = bankAccountCreateRequest.CustomerName;
            _bankRepository.Add(bankAccount);

            bankAccountCreateResponse.BankAccountId = bankAccount.AccountNo;
            bankAccountCreateResponse.Success = true;

            return bankAccountCreateResponse;
        }

        public void Deposit(DepositRequest depositRequest)
        {
            BankAccount bankAccount = _bankRepository.FindBy(depositRequest.AccountId);

            bankAccount.Deposit(depositRequest.Amount, "");

            _bankRepository.Save(bankAccount); 
        }

        public void Withdrawal(WithdrawalRequest withdrawalRequest)
        {
            BankAccount bankAccount = _bankRepository.FindBy(withdrawalRequest.AccountId);

            bankAccount.Withdraw(withdrawalRequest.Amount, "");

            _bankRepository.Save(bankAccount); 
        }

        public TransferResponse Transfer(TransferRequest request)
        {
            TransferResponse response = new TransferResponse();

            try
            {
                _bankAccountService.Transfer(request.AccountIdTo, request.AccountIdFrom, request.Amount);
                response.Success = true;
            }
            catch (InsufficientFundsException)
            {
                response.Message = "There is not enough funds in account no: " + request.AccountIdFrom.ToString();
                response.Success = false;
            }

            return response;
        }
        
        public FindAllBankAccountResponse GetAllBankAccounts()
        {
            FindAllBankAccountResponse FindAllBankAccountResponse = new FindAllBankAccountResponse();            
            IList<BankAccountView> bankAccountViews = new List<BankAccountView>();            
            FindAllBankAccountResponse.BankAccountView = bankAccountViews;

            foreach (BankAccount acc in _bankRepository.FindAll())
            {
                bankAccountViews.Add(ViewMapper.CreateBankAccountViewFrom(acc));
            }

            return FindAllBankAccountResponse;
        }
                
        public FindBankAccountResponse GetBankAccountBy(Guid Id)
        {
            FindBankAccountResponse bankAccountResponse = new FindBankAccountResponse();
            BankAccount acc = _bankRepository.FindBy(Id);
            BankAccountView bankAccountView = ViewMapper.CreateBankAccountViewFrom(acc);

            foreach (Transaction tran in acc.GetTransactions())
            {
                bankAccountView.Transactions.Add(ViewMapper.CreateTransactionViewFrom(tran));
            }

            bankAccountResponse.BankAccount = bankAccountView; 

            return bankAccountResponse;
        }
        
    }
}
