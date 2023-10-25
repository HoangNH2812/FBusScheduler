using System;
using System.Collections.Generic;

namespace Team6._FbusSchedule_.Repository.ViewModel;

public partial class TripVM
{
    public string RouteName { get; set; }

    public int? MaxTicket { get; set; }

    public int? RouteId { get; set; }

    public int? BusId { get; set; }

    public int? DriverId { get; set; }

    public bool? Status { get; set; }

    //public virtual BusVM Bus { get; set; }

    //public virtual DetailTripVM DetailTrip { get; set; }

    //public virtual DriverVM Driver { get; set; }

    //public virtual RouteVM Route { get; set; }
}
