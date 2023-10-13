using System;
using System.Collections.Generic;

namespace Team6._FbusSchedule_.Repository.ViewModel;

public partial class BusVM
{
    public int BusNumber { get; set; }

    public string CurrentLocation { get; set; }

    public bool? BusStatus { get; set; }

    public int? TotalSeats { get; set; }

    public bool? Status { get; set; }

}
