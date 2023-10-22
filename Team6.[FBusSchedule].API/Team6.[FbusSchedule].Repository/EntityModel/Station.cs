using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Team6._FbusSchedule_.Repository.EntityModel;

public partial class Station
{
    public int StationId { get; set; }

    public string StationName { get; set; }

    public string Location { get; set; }

    public bool? StationStatus { get; set; }
    [JsonIgnore]
    public virtual ICollection<DetailTrip> DetailTrips { get; set; } = new List<DetailTrip>();
    [JsonIgnore]
    public virtual ICollection<Routation> Routations { get; set; } = new List<Routation>();
    [JsonIgnore]
    public virtual ICollection<TicketStation> TicketStations { get; set; } = new List<TicketStation>();
}
