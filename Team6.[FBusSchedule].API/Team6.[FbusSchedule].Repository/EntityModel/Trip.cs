using System;
using System.Collections.Generic;

namespace Team6._FbusSchedule_.Repository.EntityModel;

public partial class Trip
{
    public int TripId { get; set; }

    public string RouteName { get; set; }

    public int? MaxTicket { get; set; }

    public int? RouteId { get; set; }

    public int? BusId { get; set; }

    public int? DriverId { get; set; }

    public bool? Status { get; set; }

    public virtual Bus Bus { get; set; }

    public virtual DetailTrip DetailTrip { get; set; }

    public virtual Driver Driver { get; set; }

    public virtual Route Route { get; set; }
}
