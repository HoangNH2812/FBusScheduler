using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team6._FbusSchedule_.Repository.DTO
{
    public class CustomerDTO
    {
        public int CustomerId { get; set; }

        public string CustomerName { get; set; }

        public int? Age { get; set; }

        public string Email { get; set; }

        public bool? Status { get; set; }
    }
}
