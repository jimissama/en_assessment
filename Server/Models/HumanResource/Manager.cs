
namespace Server.Models
{
    public class Manager : IEmployee, IManager
    {
        public string Name { get; set; } = string.Empty;
    }
}