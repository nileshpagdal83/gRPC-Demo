using System.Collections.Generic;

namespace EmployeeManagement.Contracts
{
    public interface IEmployeeManagement
    {
        IList<Employee> GetEmployeeList();
        Employee GetEmployeeById(int employeeId);
        bool AddEmployee(Employee employee);
    }
}
