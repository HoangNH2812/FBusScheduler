using System;
using System.Collections.Generic;
using Team6._FbusSchedule_.Repository.EntityModel;

namespace Team6._FbusSchedule_.Repository.ViewModel;

public partial class RoutationVM
{
    public int StationId { get; set; }

    public int? StationIndex { get; set; }

    public int? StationMode { get; set; }

    public DateTime? DefaultDuration { get; set; }

    public virtual RouteVM Route { get; set; }

    public virtual StationVM Station { get; set; }
}
