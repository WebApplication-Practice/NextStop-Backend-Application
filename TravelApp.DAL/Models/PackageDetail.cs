using System;
using System.Collections.Generic;

namespace TravelApp.DAL.Models;

public partial class PackageDetail
{
    public int PackageDetailsId { get; set; }

    public int? PackageId { get; set; }

    public string PlcesToVisit { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int NoOfDays { get; set; }

    public int NoOfNights { get; set; }

    public string? Accomodation { get; set; }

    public decimal? PricePerAdult { get; set; }

    public virtual Package? Package { get; set; }
}
