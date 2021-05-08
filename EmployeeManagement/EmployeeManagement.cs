using System.Collections.Generic;
using System.Linq;
using EmployeeManagement.Contracts;

namespace EmployeeManagement
{
    public class EmployeeManagement: IEmployeeManagement
    {
        private readonly IList<Employee> _employeeList;

        public EmployeeManagement()
        {
            _employeeList = new List<Employee>
            {
                new Employee {Id = 1, FirstName = "Albert", LastName = "Deshpande", Address = "Pune"},
                new Employee {Id = 2, FirstName = "Sopanrao", LastName = "Gupta", Address = "Mumbai"},
                new Employee {Id = 3, FirstName = "Micky", LastName = "Kelkar", Address = "Nasik"},
                new Employee {Id = 4, FirstName = "Babu", LastName = "Lal", Address = "Goa"},
                new Employee {Id = 5, FirstName = "Venkat", LastName = "Disoza", Address = "Delhi"},
                new Employee {Id = 6, FirstName = "Munna", LastName = "Swami", Address = "Solapur"}
            };
        }

        public IList<Employee> GetEmployeeList()
        {
            return _employeeList;
        }

        public Employee GetEmployeeById(int employeeId)
        {
            return _employeeList.FirstOrDefault(emp => emp.Id == employeeId);
        }

        public bool AddEmployee(Employee employee)
        {
            if (_employeeList.Any(emp => emp.Id == employee.Id))
                return false;
            _employeeList.Add(employee);
            return true;
        }
    }
}
