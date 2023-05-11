using System;
using System.Collections.Generic;

namespace TravelApp.DAL.Models;

public partial class Employee
{
    public int EmpId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public byte? RoleId { get; set; }

    public string? EmailId { get; set; }

    public virtual Role? Role { get; set; }
}
