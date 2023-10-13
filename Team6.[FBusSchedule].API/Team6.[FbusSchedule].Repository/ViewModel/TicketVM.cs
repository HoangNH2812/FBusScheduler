using System;
using System.Collections.Generic;

namespace Team6._FbusSchedule_.Repository.ViewModel;

public partial class TicketVM
{
    public string CustomerName { get; set; }

    public DateTime? DeparturTime { get; set; }

    public DateTime? ArrivalTime { get; set; }

    public string Comment { get; set; }

    public int? Status { get; set; }

    public int? CustomerId { get; set; }

    public virtual CustomerVM Customer { get; set; }
}
