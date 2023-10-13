using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team6._FbusSchedule_.Repository.DTO
{
    public class RouteDTO
    {
        public int RouteId { get; set; }

        public string StartingLocation { get; set; }

        public string Destination { get; set; }

        public string Distance { get; set; }

        public string RouteName { get; set; }

        public bool? Status { get; set; }
    }
}
