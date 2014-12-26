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
    public class UnitOfWorkTests
    {
        [Test]
        public void UnitOfWorkRepository_Is_Used_For_The_Real_Persistence_When_Commit_Is_Called_On_The_Unit_Of_Work()
        {
            Account accountToBeAmended = new Account();
            Account accountToBeRemoved = new Account();
            Account accountToBeAdded = new Account();

            Infrastructure.UnitOfWork uow = new Infrastructure.UnitOfWork();

            var uowRepositoryMockery = new Mock<IUnitOfWorkRepository>();

            IUnitOfWorkRepository uowRepository = uowRepositoryMockery.Object;

            uowRepositoryMockery.Setup(uowr => uowr.PersistCreationOf(accountToBeAdded));
            uowRepositoryMockery.Setup(uowr => uowr.PersistDeletionOf(accountToBeRemoved));
            uowRepositoryMockery.Setup(uowr => uowr.PersistUpdateOf(accountToBeAmended));
            
            uow.RegisterNew(accountToBeAdded, uowRepository);
            uow.RegisterAmended(accountToBeAmended, uowRepository);
            uow.RegisterRemoved(accountToBeRemoved, uowRepository);

            uow.Commit();

            uowRepositoryMockery.VerifyAll();

        }
    }
}
