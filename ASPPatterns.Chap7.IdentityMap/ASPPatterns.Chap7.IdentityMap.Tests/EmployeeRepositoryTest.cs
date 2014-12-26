using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using ASPPatterns.Chap7.IdentityMap.Model;
using ASPPatterns.Chap7.IdentityMap.Repository; 

namespace ASPPatterns.Chap7.IdentityMap.Tests
{
    [TestFixture]
    public class EmployeeRepositoryTest
    {        
        [Test]
        public void The_Identity_Map_Will_Return_The_Instance_Of_An_Employee_From_A_Repository()
        {
            Employee employeeToFind = new Employee { Id = new Guid("0b7f95b0-be8b-4758-a994-c4ab81d33b40"), 
                                                             FirstName = "Steve", 
                                                             LastName = "Mills"};

            IEmployeeRepository employeeRepositoryA = new StubEmployeeRepository(new IdentityMap<Employee>(), employeeToFind);

            Employee EmpoyeeAFromRepositoryA = employeeRepositoryA.FindBy(employeeToFind.Id);

            EmpoyeeAFromRepositoryA.LastName = "Mills-Stone";

            Employee EmpoyeeBFromRepositoryA = employeeRepositoryA.FindBy(employeeToFind.Id);

            Assert.AreEqual(EmpoyeeAFromRepositoryA.LastName, EmpoyeeBFromRepositoryA.LastName);

            IEmployeeRepository employeeRepositoryB = new StubEmployeeRepository(new IdentityMap<Employee>(), employeeToFind);

            Employee EmpoyeeCFromRepositoryB = employeeRepositoryB.FindBy(employeeToFind.Id);

            Assert.AreNotEqual(EmpoyeeAFromRepositoryA.LastName, EmpoyeeCFromRepositoryB.LastName);
        }
    }
}