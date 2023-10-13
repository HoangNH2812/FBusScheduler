using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team6._FbusSchedule_.Repository.DTO
{
    public class BusDTO
    {
        public int BusId { get; set; }

        public int BusNumber { get; set; }

        public string CurrentLocation { get; set; }

        public bool BusStatus { get; set; }

        public int? TotalSeats { get; set; }

        public bool? Status { get; set; }

    }
}
