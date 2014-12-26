using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ASPPatterns.Chap7.QueryObject.Infrastructure.Query;
using System.Data.SqlClient;
using System.Data;

namespace ASPPatterns.Chap7.QueryObject.Repository
{
    public static class OrderQueryTranslator
    {
        private static string baseSelectQuery = "SELECT * FROM Orders ";

        public static void TranslateInto(this Query query, SqlCommand command)
        {
            if (query.IsNamedQuery())
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = query.Name.ToString();

                foreach (Criterion criterion in query.Criteria)
                {
                    command.Parameters.Add(new SqlParameter("@" + criterion.PropertyName, criterion.Value));
                }
            }
            else
            {
                StringBuilder sqlQuery = new StringBuilder();
                sqlQuery.Append(baseSelectQuery);

                bool _isNotfirstFilterClause = false;

                if (query.Criteria.Count() > 0)
                    sqlQuery.Append("WHERE ");   

                foreach (Criterion criterion in query.Criteria)
                {
                    if (_isNotfirstFilterClause)
                        sqlQuery.Append(GetQueryOperator(query));                                            

                    sqlQuery.Append(AddFilterClauseFrom(criterion));

                    command.Parameters.Add(new SqlParameter("@" + criterion.PropertyName, criterion.Value));

                    _isNotfirstFilterClause = true;
                }

                sqlQuery.Append(GenerateOrderByClauseFrom(query.OrderByProperty));

                command.CommandType = CommandType.Text; 
                command.CommandText = sqlQuery.ToString();
            }
        }

        private static string GenerateOrderByClauseFrom(OrderByClause orderByClause)
        {
            return String.Format("ORDER BY {0} {1}",
                FindTableColumnFor(orderByClause.PropertyName), orderByClause.Desc ? "DESC" : "ASC");          
        }

        private static string GetQueryOperator(Query query)
        {
            if (query.QueryOperator == QueryOperator.And)
                return "AND ";
            else
                return "OR ";
        }

        private static string AddFilterClauseFrom(Criterion criterion)
        {
            return string.Format("{0} {1} @{2} ", FindTableColumnFor(criterion.PropertyName), FindSQLOperatorFor(criterion.criteriaOperator), criterion.PropertyName);
        }

        private static string FindSQLOperatorFor(CriteriaOperator criteriaOperator)
        {
            switch (criteriaOperator)
            { 
                case CriteriaOperator.Equal:
                    return "=";
                case CriteriaOperator.LessThanOrEqual:
                    return "<=";
                default:
                    throw new ApplicationException("No operator defined.");
            }
        }

        private static string FindTableColumnFor(string propertyName)
        {
            switch (propertyName)
            {
                case "CustomerId":
                    return "CustomerId";
                case "OrderDate":
                    return "OrderDate";
                default:
                    throw new ApplicationException("No column defined for this property.");
            }
        }
    }
}
