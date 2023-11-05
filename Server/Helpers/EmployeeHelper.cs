
using Server.Models;

namespace Server.Helpers
{
    public static class EmployeeHelper
    {        
        public static void GetEmployeeName(IEmployee employee)
        {
            Console.WriteLine(employee.Name);
        }
    }
}