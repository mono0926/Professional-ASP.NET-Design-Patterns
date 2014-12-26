using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ASPPatterns.Chap7.UnitOfWork.Infrastructure;
using ASPPatterns.Chap7.UnitOfWork.Model;
using ASPPatterns.Chap7.UnitOfWork.Repository;
using Moq;
using NUnit.Framework;

namespace ASPPatterns.Chap7.UnitOfWork.Tests
{
    [TestFixture]
    public class AccountRepositoryTests
    {
        [Test]
        public void AccountRepository_Delegates_Changes_To_The_Unit_Of_Work_Instance()
        {
            Account accountToBeAmended = new Account();
            Account accountToBeRemoved = new Account();
            Account accountToBeAdded = new Account();

            var unitOfWorkMockery = new Mock<IUnitOfWork>();

            AccountRepository accountRepository = new AccountRepository(unitOfWorkMockery.Object);
            
            unitOfWorkMockery.Setup(uow => uow.RegisterAmended(accountToBeAmended, accountRepository));
            unitOfWorkMockery.Setup(uow => uow.RegisterNew(accountToBeAdded, accountRepository));
            unitOfWorkMockery.Setup(uow => uow.RegisterRemoved(accountToBeRemoved, accountRepository));

            accountRepository.Add(accountToBeAdded);
            accountRepository.Save(accountToBeAmended);
            accountRepository.Remove(accountToBeRemoved);

            unitOfWorkMockery.VerifyAll();

        }        
    }
}
