using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using ASPPatterns.Chap7.Concurrency.Model;
using ASPPatterns.Chap7.Concurrency.Repository;
using System.Data.SqlClient;

namespace ASPPatterns.Chap7.Concurrency.Test
{
    [TestFixture()]
    public class PersonRepositoryTest
    {
        private static string _dbConnectionString = @"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Projects\Wrox ASP.NET Design Patterns\ASPPatterns.Chap7.Concurrency\ASPPatterns.Chap7.Concurrency.Test\People.mdf;Integrated Security=True;User Instance=True";
        private static Guid _personId = new Guid("0b7f95b0-be8b-4758-a994-c4ab81d33b40");

        [SetUp]
        public void Clean_The_Database_Then_Add_A_Test_Person()
        {
            using (SqlConnection connection =
                      new SqlConnection(_dbConnectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "DELETE People";                
                connection.Open();
                command.ExecuteNonQuery();
            }

            IPersonRepository personRepository = new PersonRepository(_dbConnectionString);
            
            Person personToAdd = new Person();
            personToAdd.FirstName = "Lynsey";
            personToAdd.LastName = "Millett";
            personToAdd.Id = _personId;
            personToAdd.Version = 1;

            personRepository.Add(personToAdd);
        }

        [Test]
        [ExpectedException(typeof(ApplicationException))]
        public void An_Exception_Will_Be_Thrown_When_Trying_To_Update_A_Modified_Person()
        {
            IPersonRepository personRepository = new PersonRepository(_dbConnectionString);

            Person personToChangeA = personRepository.FindBy(_personId);
            Person personToChangeB = personRepository.FindBy(_personId);

            Assert.AreEqual(personToChangeA.Version, personToChangeB.Version);

            personToChangeA.FirstName = "Doris";
            // Once the person is saved the version number is generated
            personRepository.Save(personToChangeA);

            Assert.AreNotEqual(personToChangeA.Version, personToChangeB.Version); 

            // This person is now stale and has an old version number
            // saving this person will cause an exception to be thrown.
            personToChangeB.FirstName = "Dasiy";            
            personRepository.Save(personToChangeB);
        }
    }
}
