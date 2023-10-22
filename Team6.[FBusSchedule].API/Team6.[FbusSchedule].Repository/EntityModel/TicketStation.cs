using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Team6._FbusSchedule_.Repository.EntityModel;

public partial class TicketStation
{
    public int TicketId { get; set; }

    public int StationId { get; set; }

    public DateTime? CheckInTime { get; set; }

    public DateTime? CheckOutTime { get; set; }
    [JsonIgnore]
    public virtual Station Station { get; set; }
    [JsonIgnore]
    public virtual Ticket Ticket { get; set; }
}
