using System;
using System.Collections.Generic;

namespace TravelApp.DAL.Models;

public partial class PackageCategory
{
    public int PackageCategoryId { get; set; }

    public string PackageCategoryName { get; set; } = null!;

    public virtual ICollection<Package> Packages { get; set; } = new List<Package>();
}
