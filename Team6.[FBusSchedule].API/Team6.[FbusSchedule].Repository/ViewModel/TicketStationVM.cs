using System;
using System.Collections.Generic;

namespace Team6._FbusSchedule_.Repository.ViewModel;

public partial class TicketStationVM
{
    public int StationId { get; set; }

    public DateTime? CheckInTime { get; set; }

    public DateTime? CheckOutTime { get; set; }

    public virtual StationVM Station { get; set; }

    public virtual TicketVM Ticket { get; set; }
}
