using System;
using System.Collections.Generic;

namespace Team6._FbusSchedule_.Repository.EntityModel;

public partial class Customer
{
    public long CustomerId { get; set; }

    public string CustomerName { get; set; }

    public int? Age { get; set; }

    public string Email { get; set; }

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
