using System;
using System.Collections.Generic;

namespace Team6._FbusSchedule_.Repository.EntityModel;

public partial class Driver
{
    public int DriverId { get; set; }

    public string DriverName { get; set; }

    public string? DriverPhone { get; set; }

    public bool? License { get; set; }

    public bool? DriverStatus { get; set; }

    public bool? Status { get; set; }

    public virtual ICollection<Trip> Trips { get; set; } = new List<Trip>();
}
