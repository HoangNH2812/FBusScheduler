using System;
using System.Collections.Generic;

namespace Team6._FbusSchedule_.Repository.ViewModel;

public partial class RouteVM
{
    public string StartingLocation { get; set; }

    public string Destination { get; set; }

    public string Distance { get; set; }

    public string RouteName { get; set; }

    public bool? Status { get; set; }

}
