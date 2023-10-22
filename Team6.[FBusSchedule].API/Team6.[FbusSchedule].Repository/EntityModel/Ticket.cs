using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Team6._FbusSchedule_.Repository.EntityModel;

public partial class Ticket
{
    public int TicketId { get; set; }

    public string CustomerName { get; set; }

    public DateTime? DeparturTime { get; set; }

    public DateTime? ArrivalTime { get; set; }

    public string Comment { get; set; }

    public int? Status { get; set; }

    public int? CustomerId { get; set; }
    public int? TripId { get; set; }
    [JsonIgnore]
    public virtual Customer Customer { get; set; }
    [JsonIgnore]
    public virtual ICollection<TicketStation> TicketStations { get; set; } = new List<TicketStation>();
}
