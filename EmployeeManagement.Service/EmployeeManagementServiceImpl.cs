using System;
using System.Threading.Tasks;
using EmployeeManagement.Contracts;
using EmployeeManagement.Protobuf;
using Google.Protobuf.Collections;
using Grpc.Core;

namespace EmployeeManagement.Service
{
    public class EmployeeManagementServiceImpl : EmployeeManagementOpsService.EmployeeManagementOpsServiceBase
    {
        private readonly IEmployeeManagement _employeeManagement;

        public EmployeeManagementServiceImpl(IEmployeeManagement employeeManagement)
        {
            _employeeManagement = employeeManagement;
        }

        public override Task<EmployeeListResponse> GetEmployeeList(EmployeeListRequest request, ServerCallContext context)
        {
            try
            {
                var employeeList = _employeeManagement.GetEmployeeList();
                var employeeMessageList = new RepeatedField<EmployeeMessage>();

                foreach (var employee in employeeList)
                {
                    var empployee = new EmployeeMessage
                    {
                        Id = employee.Id, FirstName = employee.FirstName, LastName = employee.LastName,
                        Address = employee.Address
                    };
                    employeeMessageList.Add(empployee);
                }
                return Task.FromResult(new EmployeeListResponse { EmployeeList = { employeeMessageList } });
                
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public override Task<EmployeeResponse> GetEmployeeById(EmployeeByIdRequest request, ServerCallContext context)
        {
            try
            {
                var employee = _employeeManagement.GetEmployeeById(request.Id);
                return Task.FromResult(new EmployeeResponse
                {
                    Employee = new EmployeeMessage
                    {
                        Id = employee.Id, FirstName = employee.FirstName, LastName = employee.LastName,
                        Address = employee.Address
                    }
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override Task<AddEmployeeResponse> AddEmployee(EmployeeRequest request, ServerCallContext context)
        {
            try
            {
                var employeeMessage = request.Employee;
                var employee = new Employee
                {
                    Id = employeeMessage.Id, FirstName = employeeMessage.FirstName, LastName = employeeMessage.LastName,
                    Address = employeeMessage.Address
                };

                var isAdded = _employeeManagement.AddEmployee(employee);
                return Task.FromResult(new AddEmployeeResponse {IsAdded = true});

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}
