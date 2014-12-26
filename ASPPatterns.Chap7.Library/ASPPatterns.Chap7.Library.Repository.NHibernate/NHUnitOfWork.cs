using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ASPPatterns.Chap7.Library.Infrastructure;
using NHibernate;
using ASPPatterns.Chap7.Library.Infrastructure.UnitOfWork; 

namespace ASPPatterns.Chap7.Library.Repository.NHibernate
{
    public class NHUnitOfWork : IUnitOfWork 
    {                             
        public void RegisterAmended(IAggregateRoot entity, IUnitOfWorkRepository unitofWorkRepository)
        {
            SessionFactory.GetCurrentSession().SaveOrUpdate(entity);
        }

        public void RegisterNew(IAggregateRoot entity, IUnitOfWorkRepository unitofWorkRepository)
        {
            SessionFactory.GetCurrentSession().Save(entity);
        }

        public void RegisterRemoved(IAggregateRoot entity, IUnitOfWorkRepository unitofWorkRepository)
        {
            SessionFactory.GetCurrentSession().Delete(entity);
        }   

        public void Commit()
        {
            using (ITransaction transaction = SessionFactory.GetCurrentSession().BeginTransaction())
            {
                try
                { transaction.Commit(); }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
    }
}