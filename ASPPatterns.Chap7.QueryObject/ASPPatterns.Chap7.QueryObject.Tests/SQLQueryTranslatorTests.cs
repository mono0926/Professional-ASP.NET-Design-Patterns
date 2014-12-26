using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using ASPPatterns.Chap7.QueryObject.Infrastructure.Query;
using ASPPatterns.Chap7.QueryObject.Repository;
using NUnit.Framework;

namespace ASPPatterns.Chap7.QueryObject.Tests
{
    [TestFixture]
    public class SQLQueryTranslatorTests
    {
        [Test]
        public void The_Translator_Should_Produce_Valid_SQL_From_A_Query_Object()
        {
            int customerId = 9;
            string expectedSQL = "SELECT * FROM Orders WHERE CustomerId = @CustomerId ORDER BY CustomerId DESC";

            Query query = new Query();
            query.Add(new Criterion("CustomerId", customerId, CriteriaOperator.Equal));
            query.OrderByProperty = new OrderByClause { PropertyName = "CustomerId", Desc = true };

            SqlCommand command = new SqlCommand();
            query.TranslateInto(command);

            Assert.AreEqual(expectedSQL, command.CommandText);
            
        }
    }
}
