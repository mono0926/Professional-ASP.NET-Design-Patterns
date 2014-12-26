using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects;
using ASPPatterns.Chap7.Library.Model;
using ASPPatterns.Chap7.Library.Infrastructure;
using ASPPatterns.Chap7.Library.Infrastructure.UnitOfWork;
using ASPPatterns.Chap7.Library.Infrastructure.Query;

namespace ASPPatterns.Chap7.Library.Repository.EF.Repositories
{
    public class BookTitleRepository : Repository<BookTitle, string>, IBookTitleRepository
    {
        public BookTitleRepository(IUnitOfWork uow)
            : base(uow)
        { }

        public override BookTitle FindBy(string Id)
        {
            return GetObjectSet().FirstOrDefault<BookTitle>(b => b.ISBN == Id);
        }

        public override IQueryable<BookTitle> GetObjectSet()
        {
            return DataContextFactory.GetDataContext().CreateObjectSet<BookTitle>();
        }

        public override string GetEntitySetName()
        {
            return "BookTitles";
        }

        public override ObjectQuery<BookTitle> TranslateIntoObjectQueryFrom(Query query)
        {
            throw new NotImplementedException();
        }
    }    
}
