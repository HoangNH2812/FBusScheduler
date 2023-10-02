using System;
using System.Collections.Generic;

namespace Team6._FbusSchedule_.Repository.EntityModel;

public partial class Routation
{
    public long RouteId { get; set; }

    public long StationId { get; set; }

    public int? StationIndex { get; set; }

    public int? StationMode { get; set; }

    public DateTime? DefaultDuration { get; set; }

    public virtual Route Route { get; set; }

    public virtual Station Station { get; set; }
}
