using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Team6._FbusSchedule_.Repository.EntityModel;

public partial class Routation
{
    public int RouteId { get; set; }

    public int StationId { get; set; }

    public int? StationIndex { get; set; }

    public int? StationMode { get; set; }

    public DateTime? DefaultDuration { get; set; }
    [JsonIgnore]
    public virtual Route Route { get; set; }
    [JsonIgnore]
    public virtual Station Station { get; set; }
}
