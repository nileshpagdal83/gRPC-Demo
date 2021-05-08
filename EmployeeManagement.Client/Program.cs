using System;
using EmployeeManagement.Protobuf;
using Grpc.Core;

namespace EmployeeManagement.Client
{
    class Program
    {
        static void Main(string[] args)
        {

            Channel channel = new Channel("127.0.0.1:8006", ChannelCredentials.Insecure);
            var client = new EmployeeManagementOpsService.EmployeeManagementOpsServiceClient(channel);

            Console.WriteLine("Retrieving employee data...");
            Console.WriteLine();

            var response = client.GetEmployeeList(new EmployeeListRequest());
            foreach (var employee in response.EmployeeList)
            {
                Console.WriteLine($"Id: {employee.Id} Name: {employee.FirstName} {employee.LastName} Address: {employee.Address}");
            }

            Console.WriteLine();
            Console.WriteLine("Enter employee Id to get details:");
            var id= Console.ReadLine();
            if (int.TryParse(id, out int empId))
            {
                var result = client.GetEmployeeById(new EmployeeByIdRequest {Id = empId });
                Console.WriteLine($"Id: {result.Employee.Id} Name: {result.Employee.FirstName} {result.Employee.LastName} Address: {result.Employee.Address}");
            }
            else
            {
                Console.WriteLine("Employee not exist");
            }
            Console.ReadLine();
        }
    }
}
