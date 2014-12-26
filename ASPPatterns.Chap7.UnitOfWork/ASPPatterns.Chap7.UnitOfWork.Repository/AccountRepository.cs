using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ASPPatterns.Chap7.UnitOfWork.Model;
using ASPPatterns.Chap7.UnitOfWork.Infrastructure;

namespace ASPPatterns.Chap7.UnitOfWork.Repository
{
    public class AccountRepository : IAccountRepository, IUnitOfWorkRepository 
    {
        private IUnitOfWork _unitOfWork;

        public AccountRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Save(Account account)
        {            
            _unitOfWork.RegisterAmended(account, this);            
        }

        public void Add(Account account)
        {
            _unitOfWork.RegisterNew(account, this);
        }

        public void Remove(Account account)
        {
            _unitOfWork.RegisterRemoved(account, this);
        }  

        public void PersistUpdateOf(IAggregateRoot entity)
        {
            // ADO.net code to update the entity...
        }

        public void PersistCreationOf(IAggregateRoot entity)
        {
            // ADO.net code to Add the entity...
        }

        public void PersistDeletionOf(IAggregateRoot entity)
        {
            // ADO.net code to delete the entity...
        }              
    }
 
}
