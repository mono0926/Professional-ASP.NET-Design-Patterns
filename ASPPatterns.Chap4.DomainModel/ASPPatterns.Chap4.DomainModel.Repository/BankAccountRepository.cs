using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ASPPatterns.Chap4.DomainModel.Model;
using System.Data.SqlClient; 
using System.Data;
using System.Configuration;

namespace ASPPatterns.Chap4.DomainModel.Repository
{
    public class BankAccountRepository : IBankAccountRepository 
    {
        private string _connectionString;

        public BankAccountRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["BankAccountConnectionString"].ConnectionString;
        }

        public void Add(BankAccount bankAccount)
        {
            string insertSql = "INSERT INTO BankAccounts " +
                               "(BankAccountID, Balance, CustomerRef) VALUES " +
                               "(@BankAccountID, @Balance, @CustomerRef)";

            using (SqlConnection connection =
                   new SqlConnection(_connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = insertSql;

                SetCommandParametersForInsertUpdateTo(bankAccount, command);

                connection.Open();

                command.ExecuteNonQuery();
            }

            UpdateTransactionsFor(bankAccount);        
        }

        public void Save(BankAccount bankAccount)
        {
            string bankAccoutnUpdateSql = "UPDATE BankAccounts " +
                                 "SET Balance = @Balance, CustomerRef= @CustomerRef " +
                                 "WHERE BankAccountID = @BankAccountID;";

            using (SqlConnection connection =
                   new SqlConnection(_connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = bankAccoutnUpdateSql;

                SetCommandParametersForInsertUpdateTo(bankAccount, command);

                connection.Open();

                command.ExecuteNonQuery();
            }

            UpdateTransactionsFor(bankAccount);       
        }

        private static void SetCommandParametersForInsertUpdateTo(BankAccount bankAccount, SqlCommand command)
        {
            command.Parameters.Add(new SqlParameter("@BankAccountID", bankAccount.AccountNo));                      
            command.Parameters.Add(new SqlParameter("@Balance", bankAccount.Balance));                                    
            command.Parameters.Add(new SqlParameter("@CustomerRef", bankAccount.CustomerRef));                        
        }

        private void UpdateTransactionsFor(BankAccount bankAccount)
        {
            string deleteTransactionSQl = "DELETE Transactions WHERE BankAccountId = @BankAccountId;";

            using (SqlConnection connection =
                   new SqlConnection(_connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = deleteTransactionSQl;
                command.Parameters.Add(new SqlParameter("@BankAccountID", bankAccount.AccountNo));                  
                connection.Open();
                command.ExecuteNonQuery();

            }

            string insertTransactionSql = "INSERT INTO Transactions " +
                                 "(BankAccountID, Deposit, Withdraw, Reference, [Date]) VALUES " +
                                 "(@BankAccountID, @Deposit,  @Withdraw,  @Reference, @Date)";

            foreach (Transaction tran in bankAccount.GetTransactions())
            {
                using (SqlConnection connection =
                       new SqlConnection(_connectionString))
                {
                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = insertTransactionSql;

                    command.Parameters.Add(new SqlParameter("@BankAccountID", bankAccount.AccountNo));
                    command.Parameters.Add(new SqlParameter("@Deposit", tran.Deposit));
                    command.Parameters.Add(new SqlParameter("@Withdraw", tran.Withdrawal));                    
                    command.Parameters.Add(new SqlParameter("@Reference", tran.Reference));
                    command.Parameters.Add(new SqlParameter("@Date", tran.Date));
                    
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public IEnumerable<BankAccount> FindAll()
        {
            IList<BankAccount> accounts = new List<BankAccount>();
            
            string queryString = "SELECT * FROM dbo.Transactions INNER JOIN " + 
                                 "dbo.BankAccounts ON dbo.Transactions.BankAccountId = dbo.BankAccounts.BankAccountId " +
                                 "ORDER BY dbo.BankAccounts.BankAccountId;";

            using (SqlConnection connection =
                   new SqlConnection(_connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = queryString;
                
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        accounts = CreateListOfAccountsFrom(reader);
                    }                                                        
            }

            return accounts;
        }

        private IList<BankAccount> CreateListOfAccountsFrom(IDataReader datareader)
        {
            IList<BankAccount> accounts = new List<BankAccount>();
            BankAccount bankAccount;
            string id = "";
            IList<Transaction> transactions = new List<Transaction>(); 
            
            while (datareader.Read())
            {
                if (id != datareader["BankAccountId"].ToString())
                {
                    id = datareader["BankAccountId"].ToString();
                    transactions = new List<Transaction>();
                    bankAccount = new BankAccount(new Guid(id), Decimal.Parse(datareader["Balance"].ToString()), transactions, datareader["CustomerRef"].ToString());                    
                    accounts.Add(bankAccount); 
                }
                transactions.Add(CreateTransactionFrom(datareader));
            }

            return accounts;
        }

        private Transaction CreateTransactionFrom(IDataRecord rawData)
        {
            return new Transaction(Decimal.Parse(rawData["Deposit"].ToString()),
                                   Decimal.Parse(rawData["Withdraw"].ToString()),
                                   rawData["Reference"].ToString(),
                                   DateTime.Parse(rawData["Date"].ToString()));
        }
    
 
        public BankAccount FindBy(Guid AccountId)
        {
            BankAccount account;

            string queryString = "SELECT * FROM dbo.Transactions INNER JOIN " +
                                 "dbo.BankAccounts ON dbo.Transactions.BankAccountId = dbo.BankAccounts.BankAccountId " +
                                 "WHERE dbo.BankAccounts.BankAccountId = @BankAccountId;";

            using (SqlConnection connection =
                   new SqlConnection(_connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = queryString;

                SqlParameter Idparam = new SqlParameter("@BankAccountId", AccountId);              
                command.Parameters.Add(Idparam);

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {                                                            
                     account = CreateListOfAccountsFrom(reader)[0];                    
                }
            }
            return account;
        }        
    }
}
