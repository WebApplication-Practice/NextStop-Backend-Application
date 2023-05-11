using TravelApp.DAL.Models;

namespace TravelAppWebApp.Models
{
    public class Employee
    {
        public int EmpId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public byte? RoleId { get; set; }
        public string EmailId { get; set; }

        public virtual Role Role { get; set; }
    }
}
