using System;
using System.Collections.Generic;

namespace Team6._FbusSchedule_.Repository.EntityModel;

public partial class TicketStation
{
    public long TicketId { get; set; }

    public long StationId { get; set; }

    public DateTime? CheckInTime { get; set; }

    public DateTime? CheckOutTime { get; set; }

    public virtual Station Station { get; set; }

    public virtual Ticket Ticket { get; set; }
}
