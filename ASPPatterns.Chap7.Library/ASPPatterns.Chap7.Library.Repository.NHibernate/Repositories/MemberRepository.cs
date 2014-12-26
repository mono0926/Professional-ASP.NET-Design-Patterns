using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ASPPatterns.Chap7.Library.Model;
using ASPPatterns.Chap7.Library.Infrastructure;
using ASPPatterns.Chap7.Library.Infrastructure.UnitOfWork;

namespace ASPPatterns.Chap7.Library.Repository.NHibernate.Repositories
{
    public class MemberRepository : Repository<Member, Guid>, IMemberRepository 
    {
        public MemberRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        { }
    }        
}
