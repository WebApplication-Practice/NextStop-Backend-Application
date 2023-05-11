namespace TravelAppWebApp.Models
{
    public class Customer
    {
        public string EmailId { get; set; }
        public byte? RoleId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserPassword { get; set; }
        public string Gender { get; set; }
        public decimal ContactNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
    }
}
