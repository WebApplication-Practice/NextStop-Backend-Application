using System;
using System.Collections.Generic;

namespace TravelApp.DAL.Models;

public partial class BookPackage
{
    public string? EmailId { get; set; }

    public int BookingId { get; set; }

    public decimal ContactNumber { get; set; }

    public string Address { get; set; } = null!;

    public DateTime DateOfTravel { get; set; }

    public int NumberOfAdults { get; set; }

    public int? NumberOfChildren { get; set; }

    public string Status { get; set; } = null!;

    public int? PackageId { get; set; }

    public virtual ICollection<Accomodation> Accomodations { get; set; } = new List<Accomodation>();

    public virtual ICollection<CustomerCare> CustomerCares { get; set; } = new List<CustomerCare>();

    public virtual Customer? Email { get; set; }

    public virtual Package? Package { get; set; }

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual ICollection<Rating> Ratings { get; set; } = new List<Rating>();
}
