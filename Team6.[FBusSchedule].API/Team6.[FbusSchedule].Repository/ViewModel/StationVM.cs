using System;
using System.Collections.Generic;
using Team6._FbusSchedule_.Repository.EntityModel;

namespace Team6._FbusSchedule_.Repository.ViewModel;

public partial class StationVM
{
    public string StationName { get; set; }

    public string Location { get; set; }

    public bool? StationStatus { get; set; }
}
