using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects;
using ASPPatterns.Chap7.Library.Infrastructure.Query;
using ASPPatterns.Chap7.Library.Model;

namespace ASPPatterns.Chap7.Library.Repository.EF.QueryTranslators
{
    public class BookQueryTranslator : QueryTranslator 
    {
        public ObjectQuery<Book> Translate(Query query)
        {
            ObjectQuery<Book> bookQuery;

            if (query.IsNamedQuery())
            {
                bookQuery = FindEFQueryFor(query);
            }
            else
            {
                StringBuilder queryBuilder = new StringBuilder();
                IList<ObjectParameter> paraColl = new List<ObjectParameter>();
                CreateQueryAndObjectParameters(query, queryBuilder, paraColl);
                
                bookQuery = DataContextFactory.GetDataContext().Books.Include("Title")
                  .Where(queryBuilder.ToString(), paraColl.ToArray()).OrderBy(String.Format("it.{0} desc", query.OrderByProperty.PropertyName));
            }

            return bookQuery;
        }

        private ObjectQuery<Book> FindEFQueryFor(Query query)
        {
            // No complex queries have been defined in this sample.
            throw new NotImplementedException();
        }
    }
}
