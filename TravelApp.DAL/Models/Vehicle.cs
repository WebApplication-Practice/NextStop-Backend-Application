using System;
using System.Collections.Generic;

namespace TravelApp.DAL.Models;

public partial class Vehicle
{
    public int VehicleId { get; set; }

    public string VehicleName { get; set; } = null!;

    public string? VehicleType { get; set; }

    public decimal RatePerHour { get; set; }

    public decimal RatePerKm { get; set; }

    public decimal BasePrice { get; set; }

    public virtual ICollection<VehicleBooked> VehicleBookeds { get; set; } = new List<VehicleBooked>();
}
