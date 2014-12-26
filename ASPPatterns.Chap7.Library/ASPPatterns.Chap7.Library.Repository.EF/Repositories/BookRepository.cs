using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects;
using ASPPatterns.Chap7.Library.Model;
using ASPPatterns.Chap7.Library.Infrastructure;
using ASPPatterns.Chap7.Library.Infrastructure.Query;
using ASPPatterns.Chap7.Library.Infrastructure.UnitOfWork;
using ASPPatterns.Chap7.Library.Repository.EF.QueryTranslators;

namespace ASPPatterns.Chap7.Library.Repository.EF.Repositories
{
    public class BookRepository : Repository<Book, Guid>, IBookRepository 
    {           
        public BookRepository(IUnitOfWork uow) : base(uow)
        {    }

        public override Book FindBy(Guid Id)
        {
            return GetObjectSet().FirstOrDefault<Book>(b => b.Id == Id);
        }

        public override IQueryable<Book> GetObjectSet()
        {
            return DataContextFactory.GetDataContext().CreateObjectSet<Book>();
        }

        public override string GetEntitySetName()
        {
            return "Books";
        }

        public override ObjectQuery<Book> TranslateIntoObjectQueryFrom(Query query)
        {
            return new BookQueryTranslator().Translate(query); 
        }
    }
}
