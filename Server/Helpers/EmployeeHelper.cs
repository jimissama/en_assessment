
using Server.Models;

namespace Server.Helpers
{
    public static class EmployeeHelper
    {        
        /// <summary>
        /// Gets the employee's name
        /// </summary>
        /// <param name="employee"></param>
        public static void GetEmployeeName(IEmployee employee)
        {
            Console.WriteLine(employee.Name);
        }
    }
}