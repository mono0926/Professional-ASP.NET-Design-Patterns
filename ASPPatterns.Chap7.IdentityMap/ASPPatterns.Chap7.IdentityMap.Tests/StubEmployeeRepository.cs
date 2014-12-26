using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ASPPatterns.Chap7.IdentityMap.Model;
using ASPPatterns.Chap7.IdentityMap.Repository; 

namespace ASPPatterns.Chap7.IdentityMap.Tests
{
    public class StubEmployeeRepository : IEmployeeRepository 
    {
        private IdentityMap<Employee> _employeeMap;
        private Employee _employeeToFind;

        public StubEmployeeRepository(IdentityMap<Employee> employeeMap, Employee employeeToFind)
        {
            _employeeMap = employeeMap;
            _employeeToFind = employeeToFind;
        }

        public Employee FindBy(Guid Id)
        {
            Employee employee = _employeeMap.GetById(Id);

            if (employee == null)
            {                 
                employee = DatastoreFindBy(Id);
                _employeeMap.Store(employee, employee.Id);
            }

            return employee;           
        }

        private Employee DatastoreFindBy(Guid Id)
        {
            return new Employee { Id = _employeeToFind.Id, FirstName = _employeeToFind.FirstName, LastName = _employeeToFind.LastName };
        }                
    }
}
