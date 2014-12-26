using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ASPPatterns.Chap7.Library.Infrastructure;
using ASPPatterns.Chap7.Library.Infrastructure.Query;

namespace ASPPatterns.Chap7.Library.Model
{
    public interface IBookRepository
    {
        void Add(Book book);
        void Remove(Book book);
        void Save(Book book);

        Book FindBy(Guid Id);

        IEnumerable<Book> FindAll();
        IEnumerable<Book> FindAll(int index, int count);

        IEnumerable<Book> FindBy(Query query);
        IEnumerable<Book> FindBy(Query query, int index, int count);                        
    }
}
