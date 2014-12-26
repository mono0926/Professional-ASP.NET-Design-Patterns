using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects;
using ASPPatterns.Chap7.Library.Infrastructure.Query;

namespace ASPPatterns.Chap7.Library.Repository.EF.QueryTranslators
{
    public abstract class QueryTranslator
    {
        public void CreateQueryAndObjectParameters(Query query, StringBuilder queryBuilder, IList<ObjectParameter> paraColl)
        {          
            foreach (Criterion criterion in query.Criteria)
            {
                switch (criterion.criteriaOperator)
                {
                    case CriteriaOperator.Equal:
                        queryBuilder.Append(String.Format("it.{0} = @{0}", criterion.PropertyName));
                        break;
                    case CriteriaOperator.LesserThanOrEqual:
                        queryBuilder.Append(String.Format("it.{0} <= @{0}", criterion.PropertyName));
                        break;
                    default:
                        throw new ApplicationException("No operator defined");
                }

                paraColl.Add(new ObjectParameter(criterion.PropertyName, criterion.Value));
            }
        }
    }
}
