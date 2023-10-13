using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team6._FbusSchedule_.Repository.DTO
{
    public class DriverDTO
    {
        public int DriverId { get; set; }

        public string DriverName { get; set; }

        public string? DriverPhone { get; set; }

        public bool? License { get; set; }

        public bool? DriverStatus { get; set; }

        public bool? Status { get; set; }
    }
}
