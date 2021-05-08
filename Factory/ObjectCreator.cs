using EmployeeManagement.Contracts;

namespace Factory
{
    public static class ObjectCreator
    {
        public static IEmployeeManagement CreateEmployeeMaintenanceInstance() =>
            new EmployeeManagement.EmployeeManagement();
    }
}
