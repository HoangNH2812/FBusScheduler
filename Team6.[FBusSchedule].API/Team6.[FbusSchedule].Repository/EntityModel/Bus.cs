using System;
using System.Collections.Generic;

namespace Team6._FbusSchedule_.Repository.EntityModel;

public partial class Bus
{
    public long BusId { get; set; }

    public int BusNumber { get; set; }

    public string CurrentLocation { get; set; }

    public string BusStatus { get; set; }

    public int? TotalSeats { get; set; }

    public virtual ICollection<Trip> Trips { get; set; } = new List<Trip>();
}
