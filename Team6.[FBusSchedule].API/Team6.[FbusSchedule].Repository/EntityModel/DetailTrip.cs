using System;
using System.Collections.Generic;

namespace Team6._FbusSchedule_.Repository.EntityModel;

public partial class DetailTrip
{
    public long TripId { get; set; }

    public long StationId { get; set; }

    public DateTime? ArrivalTime { get; set; }

    public virtual Station Station { get; set; }

    public virtual Trip Trip { get; set; }
}
