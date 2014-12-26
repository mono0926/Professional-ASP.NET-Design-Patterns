using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ASPPatterns.Chap7.Library.Infrastructure.Query;
using ASPPatterns.Chap7.Library.Model;
using NHibernate;
using NHibernate.Criterion;

namespace ASPPatterns.Chap7.Library.Repository.NHibernate.Repositories
{
    public static class QueryTranslator
    {
        public static ICriteria TranslateIntoNHQuery<T>(this Query query)
        {
            ICriteria criteria;

            if (query.IsNamedQuery())
            {
                criteria = FindNHQueryFor(query);
            }
            else
            {
                criteria = SessionFactory.GetCurrentSession().CreateCriteria(typeof(T));

                foreach (Criterion c in query.Criteria)
                {
                    global::NHibernate.Criterion.ICriterion criterion;

                    switch (c.criteriaOperator)
                    {
                        case CriteriaOperator.Equal:
                            criterion = Expression.Eq(c.PropertyName, c.Value);
                            break;
                        case CriteriaOperator.LesserThanOrEqual:
                            criterion = Expression.Le(c.PropertyName, c.Value);
                            break;
                        default:
                            throw new ApplicationException("No operator defined");                            
                   }

                   if (query.QueryOperator == QueryOperator.And)
                       criteria.Add(Expression.Conjunction().Add(criterion));
                   else
                       criteria.Add(Expression.Disjunction().Add(criterion));
                }

                criteria.AddOrder(new Order(query.OrderByProperty.PropertyName, !query.OrderByProperty.Desc)); 
            }
            return criteria;
        }

        private static ICriteria FindNHQueryFor(Query query)
        {
            // No complex queries have been defined in this sample.
            throw new NotImplementedException();
        }
    }
}
