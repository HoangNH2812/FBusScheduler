using System;
using System.Collections.Generic;

namespace Team6._FbusSchedule_.Repository.EntityModel;

public partial class Station
{
    public Guid StationId { get; set; }

    public string StationName { get; set; }

    public string Location { get; set; }

    public bool? StationStatus { get; set; }

    public virtual ICollection<DetailTrip> DetailTrips { get; set; } = new List<DetailTrip>();

    public virtual ICollection<Routation> Routations { get; set; } = new List<Routation>();

    public virtual ICollection<TicketStation> TicketStations { get; set; } = new List<TicketStation>();
}
