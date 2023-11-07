using System;
using System.Collections.Generic;

namespace Team6._FbusSchedule_.Repository.ViewModel;

public partial class DriverVM
{
    public int DriverId { get; set; }
    public string DriverName { get; set; }

    public string? DriverPhone { get; set; }

    public bool? License { get; set; }

    public bool? DriverStatus { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }

    public bool? Status { get; set; }
}
