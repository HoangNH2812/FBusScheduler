using System;
using System.Collections.Generic;

namespace Team6._FbusSchedule_.Repository.EntityModel;

public partial class Route
{
    public long RouteId { get; set; }

    public string StartingLocation { get; set; }

    public string Destination { get; set; }

    public string Distance { get; set; }

    public string RouteName { get; set; }

    public virtual ICollection<Routation> Routations { get; set; } = new List<Routation>();

    public virtual ICollection<Trip> Trips { get; set; } = new List<Trip>();
}
