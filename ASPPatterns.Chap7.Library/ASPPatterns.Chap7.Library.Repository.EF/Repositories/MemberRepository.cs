using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects;
using ASPPatterns.Chap7.Library.Model;
using ASPPatterns.Chap7.Library.Infrastructure;
using ASPPatterns.Chap7.Library.Infrastructure.UnitOfWork;
using ASPPatterns.Chap7.Library.Repository.EF.QueryTranslators;

namespace ASPPatterns.Chap7.Library.Repository.EF.Repositories
{
    public class MemberRepository : Repository<Member, Guid>, IMemberRepository
    {
        public MemberRepository(IUnitOfWork uow) : base(uow)
        { }

        public override Member FindBy(Guid Id)
        {
            return GetObjectSet().FirstOrDefault<Member>(m => m.Id == Id);
        }

        public override IQueryable<Member> GetObjectSet()
        {
            return DataContextFactory.GetDataContext().CreateObjectSet<Member>();
        }

        public override string GetEntitySetName()
        {
            return "Members";
        }

        public override ObjectQuery<Member> TranslateIntoObjectQueryFrom(Infrastructure.Query.Query query)
        {
            return new MemberQueryTranslator().Translate(query); 
        }
    }        
}
