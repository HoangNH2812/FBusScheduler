using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

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
    [JsonIgnore]
    public virtual Bus Bus { get; set; }
    [JsonIgnore]
    public ICollection<DetailTrip> DetailTrips { get; set; }
    [JsonIgnore]
    public virtual Driver Driver { get; set; }
    [JsonIgnore]
    public virtual Route Route { get; set; }
}
