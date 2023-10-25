using System;
using System.Collections.Generic;
using Team6._FbusSchedule_.Repository.EntityModel;

namespace Team6._FbusSchedule_.Repository.ViewModel;

public partial class DetailTripVM
{
    public int TripId { get; set; }
    public int StationId { get; set; }

    public DateTime? ArrivalTime { get; set; }

    //public virtual StationVM Station { get; set; }

    //public virtual TripVM Trip { get; set; }
}
