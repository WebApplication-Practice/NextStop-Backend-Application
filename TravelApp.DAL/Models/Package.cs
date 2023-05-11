using System;
using System.Collections.Generic;

namespace TravelApp.DAL.Models;

public partial class Package
{
    public int PackageId { get; set; }

    public string PackageName { get; set; } = null!;

    public int? PackageCategoryId { get; set; }

    public string? TypeOfPackage { get; set; }

    public virtual ICollection<BookPackage> BookPackages { get; set; } = new List<BookPackage>();

    public virtual ICollection<Hotel> Hotels { get; set; } = new List<Hotel>();

    public virtual PackageCategory? PackageCategory { get; set; }

    public virtual ICollection<PackageDetail> PackageDetails { get; set; } = new List<PackageDetail>();
}
