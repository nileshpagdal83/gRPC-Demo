using System;
using System.Runtime.CompilerServices;
using System.Threading;
using EmployeeManagement.Protobuf;
using Factory;
using Grpc.Core;
using GrpcServer = Grpc.Core.Server;

namespace EmployeeManagement.Service
{
    class Program
    {
        private const string ServerIpAddress = "127.0.0.1";
        private const int ServerPort = 8006;
        private static GrpcServer _server;
        static void Main(string[] args)
        {

            try
            {

                var employeeMaintenance = ObjectCreator.CreateEmployeeMaintenanceInstance();
                _server = new GrpcServer
                {
                    Services =
                    {
                        EmployeeManagementOpsService.BindService(new EmployeeManagementServiceImpl(employeeMaintenance))
                    },
                    Ports = { new ServerPort(ServerIpAddress, ServerPort, ServerCredentials.Insecure) }
                };
                _server.Start();
                Console.WriteLine("Employee management service running...");
                Console.WriteLine();
                Console.WriteLine("Press Enter to exit");
                Console.ReadLine();
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                _server?.ShutdownAsync();
                Environment.Exit(0);
            }
            
        }
    }
}
