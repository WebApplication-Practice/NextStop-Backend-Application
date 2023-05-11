using System;
using System.Collections.Generic;

namespace TravelApp.DAL.Models;

public partial class Customer
{
    public string EmailId { get; set; } = null!;

    public byte? RoleId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string UserPassword { get; set; } = null!;

    public string Gender { get; set; } = null!;

    public decimal ContactNumber { get; set; }

    public DateTime DateOfBirth { get; set; }

    public string Address { get; set; } = null!;

    public virtual ICollection<BookPackage> BookPackages { get; set; } = new List<BookPackage>();

    public virtual Role? Role { get; set; }
}
