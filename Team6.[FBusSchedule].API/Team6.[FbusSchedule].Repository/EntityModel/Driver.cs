using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Team6._FbusSchedule_.Repository.EntityModel;

public partial class Driver
{
    public int DriverId { get; set; }

    public string DriverName { get; set; }

    public string? DriverPhone { get; set; }

    public bool? License { get; set; }
    public bool? DriverStatus { get; set; }
    public string? Email { get; set; }
    [JsonIgnore]
    public string? Password { get; set; }
    public bool? Status { get; set; }
    [JsonIgnore]
    public virtual ICollection<Trip> Trips { get; set; } = new List<Trip>();
}
