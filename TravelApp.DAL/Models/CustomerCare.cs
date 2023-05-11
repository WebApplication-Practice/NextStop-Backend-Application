using System;
using System.Collections.Generic;

namespace TravelApp.DAL.Models;

public partial class CustomerCare
{
    public int QueryId { get; set; }

    public int? BookingId { get; set; }

    public string? Query { get; set; }

    public string? QueryStatus { get; set; }

    public string? Assignee { get; set; }

    public string? QueryAnswer { get; set; }

    public virtual BookPackage? Booking { get; set; }
}
