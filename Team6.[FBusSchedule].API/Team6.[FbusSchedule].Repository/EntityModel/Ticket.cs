using System;
using System.Collections.Generic;

namespace Team6._FbusSchedule_.Repository.EntityModel;

public partial class Ticket
{
    public Guid TicketId { get; set; }

    public string StudentName { get; set; }

    public DateTime DepartureTime { get; set; }

    public DateTime ArrivalTime { get; set; }

    public string Comment { get; set; }

    public int? Status { get; set; }

    public Guid? TripId { get; set; }

    public Guid? CustomerId { get; set; }

    public virtual Customer Customer { get; set; }

    public virtual ICollection<TicketStation> TicketStations { get; set; } = new List<TicketStation>();
}
