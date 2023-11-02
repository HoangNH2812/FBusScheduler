using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Team6._FbusSchedule_.Repository.EntityModel;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string CustomerName { get; set; }

    public int? Age { get; set; }

    public string? Email { get; set; }
    
    [JsonIgnore]
    public string? Password { get; set; }
    public bool? Status { get; set; }
    [JsonIgnore]
    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
