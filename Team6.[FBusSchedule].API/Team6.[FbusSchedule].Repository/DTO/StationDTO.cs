using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team6._FbusSchedule_.Repository.DTO
{
    public class StationDTO
    {
        public int StationId { get; set; }

        public string StationName { get; set; }

        public string Location { get; set; }

        public bool? StationStatus { get; set; }
    }
}
