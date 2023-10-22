using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Team6._FbusSchedule_.Repository.EntityModel;

public partial class Route
{
    public int RouteId { get; set; }

    public string StartingLocation { get; set; }

    public string Destination { get; set; }

    public string Distance { get; set; }

    public string RouteName { get; set; }

    public bool? Status { get; set; }
    [JsonIgnore]
    public virtual ICollection<Routation> Routations { get; set; } = new List<Routation>();
    [JsonIgnore]
    public virtual ICollection<Trip> Trips { get; set; } = new List<Trip>();
}
