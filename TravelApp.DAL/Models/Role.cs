using System;
using System.Collections.Generic;

namespace TravelApp.DAL.Models;

public partial class Role
{
    public byte RoleId { get; set; }

    public string? RoleName { get; set; }

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
