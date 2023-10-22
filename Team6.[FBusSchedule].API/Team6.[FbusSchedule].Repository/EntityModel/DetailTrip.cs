using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Team6._FbusSchedule_.Repository.EntityModel;

public partial class DetailTrip
{
    public int TripId { get; set; }

    public int StationId { get; set; }

    public DateTime? ArrivalTime { get; set; }

    [JsonIgnore]
    public virtual Station Station { get; set; }
    [JsonIgnore]
    public virtual Trip Trip { get; set; }
}
