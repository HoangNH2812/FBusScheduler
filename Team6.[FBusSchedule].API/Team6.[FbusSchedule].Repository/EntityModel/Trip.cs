using System;
using System.Collections.Generic;

namespace Team6._FbusSchedule_.Repository.EntityModel;

public partial class Trip
{
    public int Trip1 { get; set; }

    public string RouteName { get; set; }

    public int? MaxTicket { get; set; }

    public Guid? RouteId { get; set; }

    public Guid? BusId { get; set; }

    public Guid? DriverId { get; set; }

    public virtual Bus Bus { get; set; }

    public virtual DetailTrip DetailTrip { get; set; }

    public virtual Driver Driver { get; set; }

    public virtual Route Route { get; set; }
}
