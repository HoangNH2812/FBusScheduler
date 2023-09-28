using System;
using System.Collections.Generic;

namespace Team6._FbusSchedule_.Repository.EntityModel;

public partial class Driver
{
    public Guid DriverId { get; set; }

    public string DriverName { get; set; }

    public long? DriverPhone { get; set; }

    public bool? License { get; set; }

    public bool? DriverStatus { get; set; }

    public virtual ICollection<Trip> Trips { get; set; } = new List<Trip>();
}
