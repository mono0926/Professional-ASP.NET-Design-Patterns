using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ASPPatterns.Chap7.UnitOfWork.Infrastructure; 

namespace ASPPatterns.Chap7.UnitOfWork.Model
{
    public class AccountService
    {
        private IAccountRepository _accountRepository;
        private IUnitOfWork _unitOfWork;
       
        public AccountService(IAccountRepository accountRepository,
                              IUnitOfWork unitOfWork)
        {
            _accountRepository = accountRepository;
            _unitOfWork = unitOfWork;            
        }
        
        public void Transfer(Account from, Account to, decimal amount)
        {
            if (from.balance >= amount)
            {
                from.balance -= amount;
                to.balance += amount;

                _accountRepository.Save(from);
                _accountRepository.Save(to);
                _unitOfWork.Commit();
            }
        }
    }
}
