using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPPatterns.Chap7.QueryObject.Infrastructure.Query
{
    public static class NamedQueryFactory
    {
        public static Query CreateRetrieveOrdersUsingAComplexQuery(Guid CustomerId)
        {
            IList<Criterion> criteria = new List<Criterion>();
            Query query = new Query(QueryName.RetrieveOrdersUsingAComplexQuery, criteria);

            criteria.Add(new Criterion ("CustomerId", CustomerId, CriteriaOperator.NotApplicable));

            return query;
        }
    }
}
